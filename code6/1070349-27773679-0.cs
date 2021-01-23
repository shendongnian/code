    class A
    {
        private B _b;
        private void EnsureB()
        {
            if (_b == null)
            {
                _b = new B(); // or whatever;
            }
        }
        public void Method1()
        {
            EnsureB();
            // Do stuff with _b
        }
        public void Method2()
        {
            EnsureB();
            // Do stuff with _b
        }
        public void Method3()
        {
            EnsureB();
            // Do stuff with _b
        }
    }
