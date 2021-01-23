    [Serializable]
    public sealed class MyClass
    {
        private Func<Input, Output> _someDelegate;
        public Func<Input, Output> SomeDelegate
        {
            get
            {
                return _someDelegate;
            }
            set
            {
                if (value == null)
                    _someDelegate = null;
                else
                    _someDelegate = new myDelegateWrapper(value).Invoke;
            }
        }
    }
