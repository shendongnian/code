    class ClassA
    {
        protected ClassA(out bool success)
        {
            success = true;
        }
    }
    class B : ClassA
    {
        [ThreadStatic]
        static bool success; // static to use in base(out success) call
        public bool Success
        {
            get;
            private set;
        }
        public B()
            : base(out success)
        {
            Success = success;
            success = false; // reset value
        }
    }
