    public MyDisposable CreateDisposable()
    {
        var myDisposable = new MyDisposable();
        try
        {
            // Additional initialization here which may throw exceptions.
            ThrowException();
        }
        catch
        {
            // If an exception occurred, then this is the last chance to
            // dispose before the object goes out of scope.
            myDisposable.Dispose();
            throw;
        }
        return myDisposable;
    }
