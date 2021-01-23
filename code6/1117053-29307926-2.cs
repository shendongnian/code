    internal class CuncurrentMessagesHelper {
        private volatile Messages _current;
        public Messages Current {
            get { return DeepClone(_current); }
            set { _current = DeepClone(value); }
        }
        private static Messages DeepClone(Messages m)
        {
            if (m == null)
                return null;
            // Assuming m.last and m.next are never null...
            return new Messages {
                last = (byte[])m.last.Clone(),
                next = (byte[])m.next.Clone()
            };
        }
     }
