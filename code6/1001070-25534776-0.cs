    public static class MyExtensions
    {
        public static Task<PingResult> SendTaskAsync(this Ping ping, string address)
        {
            var tcs = new TaskCompletionSource<PingResult>();
            PingCompletedEventHandler response = null;
            response = (s, e) =>
            {
                ping.PingCompleted -= response;
                tcs.SetResult(new PingResult() { Address = address, Reply = e.Reply });
            };
            ping.PingCompleted += response;
            ping.SendAsync(address, address);
            return tcs.Task;
        }
    }
