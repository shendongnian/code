    public class BackgroundThread
    {
    
        System.ComponentModel.BackgroundWorker worker;
    
        public BackgroundThread(System.ComponentModel.DoWorkEventHandler workerFunction, System.ComponentModel.RunWorkerCompletedEventHandler workerCallback)
        {
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.worker.DoWork += workerFunction;
            this.worker.RunWorkerCompleted += workerCallback;
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
    }
