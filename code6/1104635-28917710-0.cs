    class User
    {
        private Stopwatch _alive = Stopwatch.StartNew();
        public TimeSpan Alive { get { return _alive.Elapsed; } }
    }
