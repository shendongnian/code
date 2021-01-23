    public class MyStopWatch
    {
        private TimeSpan offset;
        private Stopwatch stopwatch = new Stopwatch();
        public MyStopWatch(TimeSpan offset)
        {
            this.offset = offset;
        }
        public TimeSpan Elapsed { get { return stopwatch.Elapsed + offset; } }
        public bool IsRunning { get { return stopwatch.IsRunning; } }
        public void Reset()
        {
            stopwatch.Reset();
        }
        public void Restart()
        {
            stopwatch.Restart();
        }
        public void Start()
        {
            stopwatch.Start();
        }
        public void Stop()
        {
            stopwatch.Stop();
        }
    }
