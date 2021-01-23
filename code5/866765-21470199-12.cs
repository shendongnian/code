    public static class UdpClientExt
    {
        public static Task<UdpReceiveResult> ReceiveAsyncWithToken(
            this UdpClient client, CancellationToken token)
        {
            return client.ReceiveAsync().WithCancellation(token);
        }
    }
