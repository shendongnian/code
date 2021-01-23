    public sealed class Operation
    {
        private TaskCompletionSource<bool> _tcs
        public Task Completion {get { return _tcs.Task;} }
        public void DoSomething3(ArgType2 arg) {...}
        ...
        public Task<bool> Execute() 
        {
            // ...
            _tcs.SetResult(false);
        }
    }
    
