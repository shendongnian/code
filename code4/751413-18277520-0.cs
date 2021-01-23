    public class Foo
    {
        public event Action A;
        public event Action B;
        public Foo()
        {
            A += M1;
        }
        private object key = new object();
        private void M1()
        {
            lock (key)
            {
                Task.Run(() => M2());
            }
        }
        private void M2()
        {
            lock (key)
            {
                if (B != null)
                    B();
            }
        }
    }
