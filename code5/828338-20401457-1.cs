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
                worker = new BackgroundWorker();
                worker.DoWork += worker_DoWork;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.RunWorkerAsync();
    
    
                // Initialize timer
                workTimer = new Timer(Tick, null,  
                                      new TimeSpan(0, 0, 0, 1),  // < Amount of time to wait before timer starts
                                      new TimeSpan(0, 0, 1, 0)); // < Tick every 1 minute interval, giving the Worker 1 minute to complete the task.
            }
            
            private static void Tick(object state)
            {
                // Stop the worker and dispose of the timer.
                worker.CancelAsync();
                workTimer.Dispose();
            }
            private static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                // Job done before timer ticked
                workTimer.Dispose();
            }
    
            private static void worker_DoWork(object sender, DoWorkEventArgs e)
            {
                // Do work    
            }
    
        }
    }
