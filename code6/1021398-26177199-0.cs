        public FaceDetectionEvent()
        {
            InitializeComponent();
            tListener = new System.Timers.Timer(1000);
            tListener.Elapsed += new System.Timers.ElapsedEventHandler(tListener_Elapsed);
            if (!this.DesignMode) {
                CreateColumns();
                GetLastTwentyEvent();
                tListener.Start();
            }
        }
