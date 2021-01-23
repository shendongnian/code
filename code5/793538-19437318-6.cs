    public partial class ListForm: Form
    {
        // Background Worker Thread for Read / Write All tasks
        private static BackgroundWorker bw = new BackgroundWorker();
            
        static ListForm()
        {
            //We move the do-work out of the instance constructor, because the work that has to be done, is not connected to our instances. So we've only one definition of our work that has to be done
            bw.DoWork += new DoWorkEventHandler(TheWorkThatHasToBeDone);
        }
        
        public ListForm()
            {
                 InitializeComponent();
            
                 // Configure the Background Worker that reads and writes all variable data
                 bw.WorkerReportsProgress = true;
                 bw.WorkerSupportsCancellation = true;
                 //no more registering on instance level 
                 bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                 bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);    
            }
        
        //Your new instance-independent doWork-Method - static here
        private static void TheWorkThatHasToBeDone(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            ReadAllArguments arguments = e.Argument as ReadAllArguments;
            //You call the instance-Method here for your specific instance you want the work to be done for
            arguments.ListForm.bw_DoWork(worker, arguments);
        }
        
        
        //Your old bw_DoWork-Method with nicer arguments - you should change the method name...
        private void bw_DoWork(BackgroundWorker worker, ReadAllArguments arguments)
            {
                DoUIWorkHandler DoReadClick;
                DoUIWorkHandler DoWriteClick;
        
                int CurrentControlCount = 1;
                string StatusText = "";
                int ProgressValue = 0;
        
                // *******************Perform a time consuming operation and report progress. 
                try
                {
                    ...
                }
            }
