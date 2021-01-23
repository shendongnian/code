        public MainWindow()
        {
            InitializeComponent();
           //if you want to disable you button you can do it here 
            BackgroundWorker _bw = new BackgroundWorker();
            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.WorkerReportsProgress = true;
            _bw.ProgressChanged += new ProgressChangedEventHandler(_bw_ProgressChanged);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.RunWorkerAsync();
           //or here
           //Display progress bar here too
        }
        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this can give you access to the UI after work is completed
            // to check that everything is ok  or hide progress bar
        }
        void _bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           //this will give you access to the UI in the middle of you work like update progress bar
        }
        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //actual work here including GetImages
            //work work work
           GetImages();
                         
        }
