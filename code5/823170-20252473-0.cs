    public Connection : IDisposable
    {
        public ExpensiveNativeConnection _nativeConnection;
        public void DoThatThing()
        {
            _nativeConnection.Foo();
        }
        public void Dispose()
        {
            _nativeConnection.Dispose;
            _nativeConnection = null;
        }
    }
    public UnDisposableConnectionCopy : Connection 
    {
        public override void Dispose(){} // does nothing;
    }
