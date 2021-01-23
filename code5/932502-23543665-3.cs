    void AppendSample(Sample s)
    {
        _samplesLock.EnterWriteLock();
        try
        {
            _samples.Add(s);
        }
        finally
        {
            _samplesLock.ExitWriteLock();
        }
    }
