    private sealed class myDelegateWrapper : MarshalByRefObject
    {
        public Output Invoke(Input input)
        {
            return _delegate(input);
        }
        private Func<Input, Output> _delegate;
        public myDelegateWrapper(Func<Input, Output> dlgt)
        {
            _delegate = dlgt;
        }
    }
