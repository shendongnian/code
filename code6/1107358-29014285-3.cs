    public static class CallContextScope
    {
        public static IDisposable Start(string name, object data)
        {
            CallContext.LogicalSetData(name, data);
            return new Cleaner(name);
        }
        private class Cleaner : IDisposable
        {
            private readonly string _name;
            private bool _isDisposed;
            public Cleaner(string name)
            {
                _name = name;
            }
            public void Dispose()
            {
                if (_isDisposed)
                {
                    return;
                }
                CallContext.FreeNamedDataSlot(_name);
                _isDisposed = true;
            }
        }
    }
