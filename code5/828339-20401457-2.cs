    using System;
    using System.ComponentModel;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static BackgroundWorker worker;
            private static Timer workTimer;
    
            private static void Main(string[] args)
            {
                Console.WriteLine("Begin work");
                worker = new BackgroundWorker();
                worker.DoWork += worker_DoWork;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.WorkerSupportsCancellation = true;
                worker.WorkerReportsProgress = true;
                worker.RunWorkerAsync();
                
                // Initialize timer
                workTimer = new Timer(Tick, null,  
                                      new TimeSpan(0, 0, 0, 10),  // < Amount of time to wait before timer starts
                                      new TimeSpan(0, 0, 0, 10)); // < Tick every 1 minute interval, giving the Worker 1 minute to complete the task.
                Console.ReadLine();
    
    
            }
    
            private static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                workTimer.Dispose();
                if (e.Cancelled) return;
    
                // Job done before timer ticked
                Console.WriteLine("Job done");
            }
    
            private static void worker_DoWork(object sender, DoWorkEventArgs e)
            {
                for (int i = 0; i < 12; i++)
                {
                    // Cancel the worker if cancellation is pending.
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    Console.WriteLine(i);
                    Thread.Sleep(1000);                
                }
            }
    
            private static void Tick(object state)
            {
                // Stop the worker and dispose of the timer.
                Console.WriteLine("Job took too long");
                worker.CancelAsync();
                worker.Dispose();
    
                workTimer.Dispose();
            }
        }
    }
