    int _disposed;
    public bool Disposed { return _disposed != 0; }
    void Dispose()
    {
      if (System.Threading.Interlocked.Exchange(ref _disposed, 1) != 0)
        Dispose(true);
      GC.SuppressFinalize(this); // In case our object holds references to *managed* resources
    }
