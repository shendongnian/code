    internal class ConcurrentMessagesHelper {
        private volatile Messages _current;
        public Messages Current {
            get { return DeepClone(_current); }
            set { _current = DeepClone(value); }
        }
        private static Messages DeepClone(Messages m)
        {
            if (m == null)
                return null;
            return new Messages {
                last = m.last == null ? null : (byte[])m.last.Clone(),
                next = m.next == null ? null : (byte[])m.next.Clone()
            };
        }
     }
