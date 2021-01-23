    public class MarqueeWrapper : IDisposable
    {
        private MarqueeControl _Source;
        public MarqueeWrapper(MarqueeControl source)
        {
            _Source = source;
            source.Stopped = false;
        }
        public void Dispose()
        {
            source.Stopped = true;
        }
    }
