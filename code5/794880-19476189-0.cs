    public Form1()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.WorkerReportsProgress = true;  
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
        }
        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default; 
        }
     void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
             
        }
