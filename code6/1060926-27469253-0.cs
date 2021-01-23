    class Example {
        private long _prop;
        public long prop {
            get { return Volatile.Read(ref _prop); }
            set { Volatile.Write(ref _prop, value); }
        }
    }
