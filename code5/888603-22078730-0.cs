    private delegate void scanTargetDelegate(IPAddress ipaddress);
    private Task<PingReply> pingAsync(IPAddress ipaddress)
        {
            var tcs = new TaskCompletionSource<PingReply>();
            try
            {
                
                AutoResetEvent are = new AutoResetEvent(false);
                Ping ping = new Ping();
                ping.PingCompleted += (obj, sender) =>
                    {
                        tcs.SetResult(sender.Reply);
                    };
                ping.SendAsync(ipaddress, new object { });
                
            }
            catch (Exception)
            {
            }
            return tcs.Task;
        }
