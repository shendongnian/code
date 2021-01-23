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
                Bitmap oldSnapshot;
                Bitmap newSnapshot = new Bitmap(value, new Size(320, 240));
                lock (BitmapLock) 
                {
                    oldSnapshot = _snapshot;
                    _snapshot = newSnapshot;
                }
                if (oldSnapshot != null)
                    oldSnapshot.Dispose();
            }
        }
    }
