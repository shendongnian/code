    internal class MyPeriodicUploader
    {
        private readonly Timer _timer;
        private Action<string, string> _uploadHandler;
        public MyPeriodicUploader(int miliseconds = 50000)
        {
            if (miliseconds <= 0) throw new ArgumentOutOfRangeException("miliseconds");
            _timer = new Timer {Interval = miliseconds};
            _timer.Tick += timer_Tick;
        }
        public string InputFile { get; set; }
        public string TargetUrl { get; set; }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (_uploadHandler != null && InputFile != null && TargetUrl != null)
            {
                _uploadHandler(InputFile, TargetUrl);
            }
        }
        public void SetUploadHandler(Action<string, string> uploadHandler)
        {
            if (uploadHandler == null) throw new ArgumentNullException("uploadHandler");
            _uploadHandler = uploadHandler;
        }
        public void StartTimer()
        {
            _timer.Start();
        }
        public void StopTimer()
        {
            _timer.Stop();
        }
        public void SetUploadInterval(int minutes)
        {
            _timer.Interval = TimeSpan.FromMinutes(minutes).Milliseconds;
        }
    }
