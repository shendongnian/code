        private async Task<bool> PingHost(string ip)
        {
            bool pingable = true;
            Ping mypinger = new Ping();
            try
            {
                PingReply reply = mypinger.Send(ip);
                pingable = (reply.Status == IPStatus.Success) ? true : false;
            }
            catch (PingException)
            {
                return false;
            }
            return pingable;
        }
