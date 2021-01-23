    private void DisconnectWithTimeout(IConnection connection, int timeoutMillis)
    {
        var task = Task.Run(() => connection.Dispose());
        if (!task.Wait(timeoutMillis))
        {
            //timeout
            throw new TimeoutException("Timeout on connection.Dispose()");
        }
    }
