    using (cancellationToken.Register(() => tcpListener.Stop()))
    {
        try
        {
            var tcpClient = await tcpListener.AcceptTcpClientAsync();
            // … carry on …
        }
        catch (InvalidOperationException)
        {
            // Either tcpListener.Start wasn't called (a bug!)
            // or the CancellationToken was cancelled before
            // we started accepting (giving an InvalidOperationException),
            // or the CancellationToken was cancelled after
            // we started accepting (giving an ObjectDisposedException).
            //
            // In the latter two cases we should surface the cancellation
            // exception, or otherwise rethrow the original exception.
            cancellationToken.ThrowIfCancellationRequested();
            throw;
        }
    }
