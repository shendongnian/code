    private struct Messages {
        public byte[] last;
        public byte[] next;
    }
    internal class ConcurrentMessagesHelper {
        private volatile StrongBox<Messages> _current;
        public Messages Current {
            get { return _current.Value; }
            set { _current = new StrongBox<Messages>(value); }
        }
    }
