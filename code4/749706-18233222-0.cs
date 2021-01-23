    public bool IsAlive(string server)
        {
            bool result = false;
            try
            {
                using (Ping pingSender = new Ping()) {
                    PingOptions options = new PingOptions();
                    options.DontFragment = true;
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;
                    PingReply reply = pingSender.Send(server, timeout, buffer, options);
                    if (reply.Status == IPStatus.Success)
                        result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
