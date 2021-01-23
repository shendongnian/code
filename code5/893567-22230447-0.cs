    public static class ThreadSafe
    {
        public static readonly object _locker = new object();
        public static Bitmap _snapshot;
        public static Bitmap GetSnapshot(int width, int height)
        {
            lock (_locker)
            {
                if (_snapshot == null)
                    return null;
                return new Bitmap(_snapshot, new Size(width, height));
            }
        }
        public static void SetSnapshot(Bitmap source, int width, int height)
        {
            lock (_locker)
            {
                if (_snapshot != null)
                    _snapshot.Dispose();
                _snapshot = new Bitmap(source, new Size(width, height));
            }
        }
    }
