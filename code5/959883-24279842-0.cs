    public void Dispose()
    {
        lock (disposableLock)
        {
            if (!isDisposed)
            {
                writer.Close();
                stream.Close();
                isDisposed = true;
            }
        }
    }
