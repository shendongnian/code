    public MyDisposable CreateDisposable()
    {
        var myDisposable = new MyDisposable();
        try
        {
            // additional initialization here which may throw exceptions
        }
        catch
        {
            // If an exception occurred, then this is the last chance to
            // to dispose before the object goes out of scope.
            myDisposable.Dispose();
            throw;
        }
        return myDisposable;
    }
