        public string PingIpadress(string ipadress)
        {
            var pingSender = new Ping();
            var options = new PingOptions();
            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;
            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(ipadress, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                return "alive " + reply.Options.Ttl;
            }
            return "no response";
        }
