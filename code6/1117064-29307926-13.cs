    internal class ConcurrentMessagesHelper {
        private volatile StrongBox<Messages> _current;
        public Messages Current {
            get { return DeepClone(_current.Value); }
            set { _current = new StrongBox<Messages>(DeepClone(value)); }
        }
        private static Messages DeepClone(Messages m)
        {
            return new Messages {
                last = m.last == null ? null : (byte[])m.last.Clone(),
                next = m.next == null ? null : (byte[])m.next.Clone()
            };
        }
    }
