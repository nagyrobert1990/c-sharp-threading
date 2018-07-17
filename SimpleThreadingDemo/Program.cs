using System;
using System.Diagnostics;
using System.Threading;

namespace SimpleThreadingDemo
{
    class Program
    {
        public static void Counting()
        {
            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine("Count: {0} - Thread Id: {1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {

            ThreadStart starter = new ThreadStart(Counting);
            Thread first = new Thread(starter);
            Thread second = new Thread(starter);

            first.Start();
            second.Start();

            first.Join();
            second.Join();

            Console.Read();

            /*
            Demo01Creation();
            Demo02Join();
            Demo03PArametrizedThreadStart();
            Demo05ThreadPool();
            */
        }

        
        /*
        public static void Demo01Creation()
        {
            Thread th = new Thread(SomeWork);
            th.Start();
            Thread.Sleep(2000);
            Console.WriteLine("Aaand it's gone!");
        }

        public static void Demo02Join()
        {
            ThreadStart operation = new ThreadStart(SomeWork);
            Thread[] theThreads = new Thread[5];

            for (int x = 0; x < 5; ++x)
            {
                theThreads[x] = new Thread(operation);
                theThreads[x].Start();
            }

            foreach (Thread t in theThreads) t.Join();
        }

        private static void SomeWork()
        {
            Console.WriteLine("I do some work here!");
        }

        public static void Demo03PArametrizedThreadStart()
        {
            var th = new Thread(ExecuteInForeground);
            th.Start(4500);
            Thread.Sleep(1000);
            Console.WriteLine("Main thread ({0}) exiting...",
                              Thread.CurrentThread.ManagedThreadId);
        }

        private static void ExecuteInForeground(Object obj)
        {
            int interval;
            try
            {
                interval = (int)obj;
            }
            catch (InvalidCastException)
            {
                interval = 5000;
            }
            DateTime start = DateTime.Now;
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Thread {0}: {1}, Priority {2}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority);
            do
            {
                Console.WriteLine("Thread {0}: Elapsed {1:N2} seconds",
                                  Thread.CurrentThread.ManagedThreadId,
                                  sw.ElapsedMilliseconds / 1000.0);
                Thread.Sleep(500);
            } while (sw.ElapsedMilliseconds <= interval);
            sw.Stop();
        }

        public static void Demo05ThreadPool()
        {
            Console.WriteLine("Demo 5 started");
            WaitCallback item = new WaitCallback(Work);
            if (!ThreadPool.QueueUserWorkItem(item, "ThreadPooled"))
            {
                Console.WriteLine("Could not queue item");
            }
        }

        static void Work(object o)
        {
            Console.WriteLine("Work started");
            string info = (string)o;
            for (int x = 0; x < 10; ++x)
            {
                Console.WriteLine("{0}: {1}", info, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }
        */
    }
}

