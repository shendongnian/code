    sealed class B : IDisposable
    {
        private readonly SqlConnection _conn;
        private bool _isDisposed;
    
        public B()
        {
            _conn = new SqlConnection(/* ... */);
        }
    
        public void Dispose()
        {
            if (_isDisposed)
                return;
    
            if (_conn != null)
                _conn.Dispose();
            
            _isDisposed = true;
        }
    }
