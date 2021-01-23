    internal static class TcpClientFactory
    {
        public static bool TryConnect(string host, int port, TimeSpan timeout, out TcpClient resultClient)
        {
            var client = new TcpClient();
            var asyncResult = client.BeginConnect(host, port, null, null);
            var success = asyncResult.AsyncWaitHandle.WaitOne(timeout);
            if (!success)
            {
                resultClient = default(TcpClient);
                return false;
            }
            client.EndConnect(asyncResult);
            resultClient = client;
            return true;
        }
    }
