    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using NUnit.Framework;
    namespace MutexResetEvent.Tests
    {
        public class Class1
        {
            private Mutex _mutex;
            private Thread _thread;
            private Process _process;
            private ManualResetEvent _event;
            [SetUp]
            public void SetUp()
            {
                Console.WriteLine("SetUp: #{0}", Thread.CurrentThread.ManagedThreadId);
                _event = new ManualResetEvent(false);
                _thread = new Thread(() =>
                {
                    Console.WriteLine("Thread: #{0}", Thread.CurrentThread.ManagedThreadId);
                    _mutex = new Mutex(true, "MutexResetEvent");
                    _process = new Process
                    {
                        StartInfo =
                        {
                            FileName = "MutexResetEvent.Worker.exe",
                            //UseShellExecute = false,
                            //RedirectStandardOutput = true
                        }
                    };
                    //_process.OutputDataReceived += (o, a) => Console.WriteLine(a.Data);
                    _process.Start();
                    //_process.BeginOutputReadLine();
                    while (!_event.WaitOne(1000))
                        Console.WriteLine("Thread: ...");
                    Console.WriteLine("Thread: #{0}", Thread.CurrentThread.ManagedThreadId);
                    _mutex.ReleaseMutex();
                    _process.WaitForExit();
                });
            }
            [Test]
            public void Test()
            {
                Console.WriteLine("Test: #{0}", Thread.CurrentThread.ManagedThreadId);
                _thread.Start();
                for (var i = 0; i < 3; i++)
                {
                    Console.WriteLine("Test: ...");
                    Thread.Sleep(1000);
                }
                /*
                if (Guid.NewGuid().GetHashCode() % 3 == 0)
                    Environment.Exit(1);
                //*/
            }
            [TearDown]
            public void TearDown()
            {
                Console.WriteLine("TearDown: #{0}", Thread.CurrentThread.ManagedThreadId);
                Task.Run(() =>
                {
                    Console.WriteLine("Task: #{0}", Thread.CurrentThread.ManagedThreadId);
                    _event.Set();
                    //_thread.Join();
                }).Wait();
                for (var i = 0; i < 3; i++)
                {
                    Console.WriteLine("TearDown: ...");
                    Thread.Sleep(1000);
                }
            }
        }
    }
.
    using System;
    using System.Threading;
    namespace MutexResetEvent.Worker
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Worker: #{0}", Thread.CurrentThread.ManagedThreadId);
                var mutex = Mutex.OpenExisting("MutexResetEvent");
                try
                {
                    while (!mutex.WaitOne(1000))
                        Console.WriteLine("Worker: ...");
                }
                catch (AbandonedMutexException)
                {
                    Console.WriteLine("Worker: AbandonedMutexException");
                }
                Console.WriteLine("Worker: #{0}", Thread.CurrentThread.ManagedThreadId);
                mutex.ReleaseMutex();
                Console.WriteLine("Worker: WOO HOO");
                Console.ReadLine();
            }
        }
    }
