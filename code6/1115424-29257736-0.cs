    public bool PingHost(string nameOrAddress)
        {
            PingReply reply;
            using (var pinger = new Ping())
            {
                reply = pinger.Send(nameOrAddress);
            }
            bool pingable=false;
            if (reply != null) pingable = reply.Status == IPStatus.Success;
            return pingable;
        }
