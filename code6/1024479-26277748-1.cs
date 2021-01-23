    var result = false;
    using (var client = new TcpClient())
    {
        try
        {
            client.ReceiveTimeout = timeout * 1000;
            client.SendTimeout = timeout * 1000;
            var asyncResult = client.BeginConnect(host, port, null, null);
            var waitHandle = asyncResult.AsyncWaitHandle;
            try
            {
                if (!asyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(timeout), false))
                {
                    // wait handle didn't came back in time
                    client.Close();
                }
                else
                {
                    // The result was positiv
                    result = client.Connected;
                }
                // ensure the ending-call
                client.EndConnect(asyncResult);
            }
            finally
            {
                // Ensure to close the wait handle.
                waitHandle.Close();
            }
        }
        catch
        {
        }
    }
    return result;
