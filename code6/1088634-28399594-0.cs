    class SerializableStopwatch
    {
        public TimeSpan BaseElapsed { get; set; }
        public TimeSpan Elapsed { get { return _stopwatch.Elapsed + BaseElapsed; } }
        private Stopwatch _stopwatch = new Stopwatch();
        // add whatever other members you want/need from the Stopwatch class,
        // simply delegating the operation to the _stopwatch member. For example:
        public void Start() { _stopwatch.Start(); }
        public void Stop() { _stopwatch.Stop(); }
        // etc.
    }
