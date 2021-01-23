    public class Counting
    {
        private readonly Object _thisLock = new Object();
        private static readonly Lazy<Counting> InstanceField =
                                new Lazy<Counting>(() => new Counting());
        public static Counting Instance // Singleton
        {
            get
            {
                return InstanceField.Value;
            }
        }
        private int _counter;
        public int Counter
        {
            get
            {
                return _counter;
            }
            set
            {
                lock (_thisLock) // Locking
                {
                    _counter = value;
                }
            }
        }
        protected Counting()
        {
        }
    }
