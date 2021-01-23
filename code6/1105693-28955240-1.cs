    public class BackgroundThread
    {
    
        System.ComponentModel.BackgroundWorker worker;
    
        public BackgroundThread(System.ComponentModel.DoWorkEventHandler workerFunction, System.ComponentModel.RunWorkerCompletedEventHandler workerCallback)
        {
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.worker.DoWork += workerFunction;
            this.worker.RunWorkerCompleted += workerCallback;
        }
    
        public BackgroundThread(Action<object> anyWorkFunctionWithObjectArgument, Action<object> anyCallback)
        {
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.worker.DoWork += (sender, e) => { anyWorkFunctionWithObjectArgument.Invoke(e.Argument); };
            this.worker.RunWorkerCompleted += (sender, e) => { anyCallback.Invoke(e.Result); };
        }
    
        public void Start(object argument)
        {
            this.worker.RunWorkerAsync(argument);
        }
    
        public static BackgroundThread GetDoNothingInstance()
        {
            return new BackgroundThread(
                (sender, e) =>
                {
                    // e is DoWorkEventArgs
                },
                (sender, e) =>
                {
                    // e is RunWorkerCompletedEventArgs
                });
        }
    
        public static BackgroundThread GetDoNothingInstance2()
        {
            Action<object> workfunction = delegate(object argument)
            {
                // Do nothing
            };
    
            Action<object> callback = delegate(object result) 
            { 
                // Do nothing
            };
    
            return new BackgroundThread(workfunction, callback);       
        }
    }
