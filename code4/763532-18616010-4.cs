    using System;
    using System.ComponentModel;
    using System.Threading;
    
    using WcfEx;
    
    public class MyForm : Form
    {
        public MyForm()
        {
            WcfHandler WcfConnection = new WcfHandler();
            WcfConnection.ProgressChanged += WcfConnectionOnProgressChanged;
        }
    
        private delegate void WcfConnectionOnProgressChangedDelegate(object Sender, WcfHandler.ProgressChangedEventArgs EventArgs);
    
        private void WcfConnectionOnProgressChanged(object Sender, WcfHandler.ProgressChangedEventArgs EventArgs)
        {
            //multi thread synchronization check
            if (this.InvokeRequired)
            {
                object[] Parameters = new object[2];
                Parameters[0] = Sender;
                Parameters[1] = EventArgs;
                this.Invoke(new WcfConnectionOnProgressChangedDelegate(WcfConnectionOnProgressChanged), Parameters);
            }
            else
            {
                if (EventArgs == null)
                    return;
    
                switch (EventArgs.StateValue)
                {
                    case WcfHandler.ProgressChangedEventArgs.State.Started:
                        {
                            this.Text = "Starting connection...";
                            break;
                        }
                    case WcfHandler.ProgressChangedEventArgs.State.Processing:
                        {
                            this.Text = "Downloading updates...";
                            break;
                        }
                    case WcfHandler.ProgressChangedEventArgs.State.Finished:
                        {
                            this.Text = EventArgs.Succes ? "Update completed" : "Update failed";
                            break;
                        }
                }
    
                Application.DoEvents();
            }
        }
    
    
        public class WcfHandler
        {
            public class ProgressChangedEventArgs : EventArgs
            {
                public enum State : int
                {
                    Started,
                    Processing,
                    Finished
                };
        
                public bool Succes { get; set; }
                public State StateValue { get; set; }
            }
        
            public delegate void ProgressChangedEventHandler(object sender, ProgressChangedEventArgs EventArgs);
        
            public event ProgressChangedEventHandler ProgressChanged;
        
            protected virtual void OnProgressChanged(ProgressChangedEventArgs e)
            {
                if (ProgressChanged != null)
                {
                    ProgressChanged(this, e);
                }
            }
        
            public void StartChecking()
            {
                BackgroundWorker bWorker = new BackgroundWorker();
        
                bWorker.DoWork += CheckStatesAsync;
                bWorker.RunWorkerCompleted += BWorkerOnRunWorkerCompleted;
        
                bWorker.RunWorkerAsync();
            }
        
            private void CheckStatesAsync(object sender, DoWorkEventArgs e)
            {
                while (true)
                {
                    WcfEx.IwcfS5ExtensionClient client = new IwcfS5ExtensionClient("MyWcfBindingConfig");
                    ProgressChangedEventArgs Controller = new ProgressChangedEventArgs();
                    Controller.StateValue = ProgressChangedEventArgs.State.Started;
                    Controller.Succes = true;
        
                    this.OnProgressChanged(Controller);
        
                    try
                    {
                        client.Open();
        
                        Controller.StateValue = ProgressChangedEventArgs.State.Processing;
                        Controller.Succes = true;
                        this.OnProgressChanged(Controller);
        
                        //do some work
                    }
                    catch (Exception)
                    {
                        this.OnProgressChanged(new ProgressChangedEventArgs()
                                                   {
                                                       StateValue = ProgressChangedEventArgs.State.Finished,
                                                       Succes = false
                                                   });
                    }
        
                    Thread.Sleep(8000);
                }
            }
        
            private void BWorkerOnRunWorkerCompleted(object Sender, RunWorkerCompletedEventArgs RunWorkerCompletedEventArgs)
            {
                ProgressChangedEventArgs Controller = new ProgressChangedEventArgs();
                Controller.StateValue = ProgressChangedEventArgs.State.Finished;
                Controller.Succes = true;
                this.OnProgressChanged(Controller);
            }
        }
