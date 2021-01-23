        public void Dispose()
        {
            if (_isDisposed)
                return;
    
            // dispose managed resources of base type
            // ...
            OnDispose();
            
            _isDisposed = true;
        }
        protected virtual void OnDispose()
        {
        }
