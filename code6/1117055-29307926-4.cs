    internal class CuncurrentMessagesHelper {
        private volatile Messages _current;
        public Messages Current {
            get { return Clone(_current); }
            set { _current = Clone(value); }
        }
        private static Messages Clone(Messages m)
        {
            if (m == null)
                return null;
            return new Messages {
                last = m.last,
                next = m.next
            };
        }
     }
