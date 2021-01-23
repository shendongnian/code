        private Object thisLock = new Object();
        private char[] _arena_snapshot;
        public char[] arena_snapshot
        {
            get
            {
                lock (thisLock)
                {
                    return _arena_snapshot;
                }
            }
            set
            {
                lock (thisLock)
                {
                    _arena_snapshot = value;
                }
            }
        }
