    public void DisposeIfApplicable(ref T value)
    {
        if(value is IDisposable)
        {
            ((IDisposable)value).Dispose();
        }
    }
