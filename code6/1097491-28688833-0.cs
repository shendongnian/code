    public abstract AMyClass
    {
        public string DoSomething()
        {
            return DoSomethingInternal();
        }
    
        internal abstract string DoSomethingInternal();
    }
