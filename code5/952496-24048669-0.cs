    class A
    {
        private B _b;
        public B b
        {
            get
            {
                _b = _b ?? new B();
                return _b;
            }
        }
    }
