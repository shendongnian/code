    public static class ThreadSafe
    {
        private static readonly object BitmapLock = new object();
        private static Bitmap _snapshot;
        public static Bitmap Snapshot
        {
            get
            {
                lock (BitmapLock)
                    return new Bitmap(_snapshot);
            }
            set
            {
                var snapshot = new Bitmap(value, new Size(320, 240));
                lock (BitmapLock)
                    _snapshot = snapshot;
            }
        }
    }
