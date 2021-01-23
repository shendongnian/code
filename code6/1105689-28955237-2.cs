    class Program
    {
        protected static void plainOldWorkerFunction(object argument)
        {
            return;
        }
        protected static void plainOldCallbackFunction()
        {
            return;
        }
        static void Main(string[] args)
        {
            BackgroundThread bt = new BackgroundThread(plainOldWorkerFunction, plainOldCallbackFunction);
            bt.Start(1234);
        }
    }
    public class BackgroundThread
    {
        BackgroundWorker worker;
        Action<object> workerAction;
        Action callbackAction;
        protected void doWork(object sender, DoWorkEventArgs e)
        {
            workerAction(e.Argument);
        }
        protected void callback(object sender, RunWorkerCompletedEventArgs e)
        {
            callbackAction();
        }
        public BackgroundThread(Action<object> workerFunction, Action workerCallback)
        {
            this.workerAction = workerFunction;
            this.callbackAction = workerCallback;
            this.worker = new BackgroundWorker();
            this.worker.DoWork += doWork;
            this.worker.RunWorkerCompleted += callback;
        }
        public void Start(object argument)
        {
            this.worker.RunWorkerAsync(argument);
        }
    }
