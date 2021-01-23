    using System;
    using System.Windows.Forms;
    using System.Threading;
    
    namespace ThreadTest
    {
        public class WorkerClass
        {
            private Thread thr;
    
            // UI control for update
            public Control UIControl { get; set; }
    
            public delegate void StatusUpdate(DateTime dateTime, string message);
            public event StatusUpdate OnStatusUpdate;
    
            // Starts thread
            public void Start()
            {
                thr = new Thread(new ThreadStart(MainWorker));
                thr.Start();
            }
    
            // Main thread worker
            public void MainWorker()
            {
                int i = 0;
    
                while (true)
                {
                    string message = string.Format("Value of i={0}", i++);
                    FireStatusUpdate(DateTime.Now, message);
    
                    Thread.Sleep(1000);
                }
            }
    
            // Fire thread safe event
            private void FireStatusUpdate(DateTime dateTime, string message)
            {
                // UIControl is set and OnStatusUpdate has subscriber
                if (UIControl != null && OnStatusUpdate != null)
                {
                    if (UIControl.InvokeRequired)
                    {
                        UIControl.Invoke(new StatusUpdate(FireStatusUpdate), 
                                                new object[] { dateTime, message });
                        return;
                    }
    
                    OnStatusUpdate(dateTime, message);
                }
            }  
        }
    }
