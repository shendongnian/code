        private readonly bool _shouldStop;
        
        public void Start()
        {
            Thread workerThread = new Thread(DoWork);
            workerThread.IsBackground = true;
            workerThread.Start();
        }
        public void DoWork()
        {            
            while (!_shouldStop)
            {
                //work
            }
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
