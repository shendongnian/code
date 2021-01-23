    void OnReceiveFrom(IAsyncObject ar)
    {
        try
        {
            // whatever you do
        }
        catch (ObjectDisposedException obex)
        {
            // log to debugging output window, just so you will know.
            Debug.WriteLine(String.Format("{0}: {1}: in OnRecieveFrom",
                obex.GetType().Name, obex.Message));
            // test some variable you set when your application is exiting.
            if (applicationIsShuttingDown)
                return;
            // but if it is unexpected, then re-throw it.
            throw;
        }
    }
