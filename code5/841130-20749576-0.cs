    public void DisposeIfApplicable(T value)
    {
        if(value is IDisposable)
        {
            ((IDisposable)value).Dispose();
        }
    }
