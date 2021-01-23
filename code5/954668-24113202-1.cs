    ...
    using (new TimerHandle(span => /* use span */)) {
        // do something that takes `span` time to execute
    }
    ...
    class TimerHandle : IDisposable
    {
        private readonly Action<TimeSpan> callback
        private readonly Stopwatch timer;
        public TimerHandle(Action<TimeSpan> callback)
        {
            this.callback = callback;
            this.timer = new Stopwatch();
            this.timer.Start();
        }
        public void Dispose()
        {
            timer.Restart();
            callback(timer.Elapsed);
        }
    }
