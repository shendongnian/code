            private readonly BackgroundWorker _backgroundWorker;
        public Form1()
        {
            InitializeComponent();
            
            _backgroundWorker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            _backgroundWorker.DoWork += backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }
        private void StartLoop()
        {
            _backgroundWorker.RunWorkerAsync();
        }
        private void StopLoop()
        {
            _backgroundWorker.CancelAsync();
        }
        private void backgroundWorker_DoWork( object sender , DoWorkEventArgs e )
        {
            var backgroundWorker = ( BackgroundWorker ) sender;
            for ( var i = 0; i < 100; i++ )
            {
                if ( backgroundWorker.CancellationPending )
                {
                    e.Cancel = true;
                    return;
                }
                // Do Work
            }
        }
        private void backgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e )
        {
            if ( e.Cancelled )
            {
                // handle cancellation
            }
            if ( e.Error != null )
            {
                // handle error
            }
            // completed without cancellation or exception
        }
