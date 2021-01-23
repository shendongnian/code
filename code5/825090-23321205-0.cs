        public static bool ConnectToInternet(int timeout_per_host_millis = 1000, string[] hosts_to_ping = null)
        {
            bool network_available = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (network_available)
            {
                string[] hosts = hosts_to_ping ?? new string[] { "www.google.com", "www.facebook.com" };
                Ping p = new Ping();
                foreach (string host in hosts)
                {
                    try
                    {
                        PingReply r = p.Send(host, timeout_per_host_millis);
                        if (r.Status == IPStatus.Success)
                            return true;
                    }
                    catch { }
                }
            }
            return false;
        }
