    void AppendSample(Sample s)
    {
        _samplesLock.EnterWriteLock();
        try
        {
            _samples.Add(s);
        }
        finally
        finally
        {
            _samplesLock.ExitWriteLock();
        }
    }
