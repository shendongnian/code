    using System;
    using System.Diagnostics;
    using System.Threading;
    
    namespace TestMutexLauncher
    {
        class Program
        {
            static void Main(string[] args)
            {
                var p = Process.Start("TestMutex");
                Console.WriteLine("Waiting for other process to release the mutex.");
                Thread.Sleep(1000); // maybe p.WaitForInputIdle is an alternative for WinForms/WPF
                Mutex mutex = null;
                for (int i = 0; i < 100; i++)
                {
                    if (Mutex.TryOpenExisting("MyUniqueMutexName", out mutex))
                        break;
                    Thread.Sleep(100);
                }
                if (mutex != null)
                {
                    try
                    {
                        mutex.WaitOne();
                        mutex.ReleaseMutex();
                    }
                    finally
                    {
                        mutex.Dispose();
                    }
                }
            }
        }
    }
