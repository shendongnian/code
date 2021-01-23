        private static Stopwatch _stopwatch = null;
        public static Stopwatch  Stopwatch 
        {
            get
            {
                if (_stopwatch == null)
                    _stopwatch = new Stopwatch();
                return _stopwatch;
            }
            set { }
        }
