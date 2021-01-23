    internal class ConcurrentMessagesHelper {
        private volatile Messages _current;
        public void SetLatest(Messages m) {
            _current = m;
        }
        public Messages ReadLatest() {
            return _current;
        }
    }
