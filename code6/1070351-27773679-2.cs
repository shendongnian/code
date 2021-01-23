    class A
    {
        private B _b;
        private B B
        {
            get
            {
                if (_b == null)
                {
                     _b = new B();
                }
                return _b;
            }
        }
        public void Method1()
        {
            // Do stuff with B
        }
        public void Method2()
        {
            // Do stuff with B
        }
        public void Method3()
        {
            // Do stuff with B
        }
    }
