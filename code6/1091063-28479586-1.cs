    public class Profiler:IDisposable
    {
        private readonly string _msg;
        private Stopwatch _sw;
        public Profiler(string msg)
        {
            _msg = msg;
            _sw = Stopwatch.StartNew();
        }
        public void Dispose()
        {
            _sw.Stop();
            LogPerformance(_msg, _sw.ElapsedMilliseconds);
        }
    }
