        public TValue this[TKey key] {
            get {
                // skipped
            }
            set {
                Insert(key, value, false);
            }
        }
 
        public void Add(TKey key, TValue value) {
            Insert(key, value, true);
        }
