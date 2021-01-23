    public void Dispose()
    {
        if (isDisposed)
            return;
        try
        {
            if (service.State == CommunicationState.Faulted)
                service.Abort();
            else
            {
                try
                {
                    service.Close();
                }
                catch (Exception closeException)
                {
                    try
                    {
                        service.Abort();
                    }
                    catch (Exception abortException)
                    {
                        throw new AggregateException(closeException, abortException);
                    }
                    throw;
                }
            }
        }
        finally
        {
            isDisposed = true;
        }
    }
