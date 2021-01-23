    public class A
    {
        private readonly object _syncLock = new object();
        public B B { get; private set; }
        public A()
        {
        }
        public void Add(B b)
        {
            lock (_syncLock)
            {
                // The actual logic
            }
        } 
    }
