       public string GetMasterFromSentinel(string sentinelAddress)
        {
            TcpClient server;
            try
            {
                var splittedAddress = sentinelAddress.Split(':');
                server = new TcpClient(splittedAddress[0], splittedAddress[1].ParseInt());
            }
            catch (SocketException)
            {
                _log.Error("Unable to connect to server");
                return string.Empty;
            }
            NetworkStream ns = server.GetStream();
            var payload = new byte[] { 0x2a, 0x32, 0x0d, 0x0a, 0x24, 0x38, 0x0d, 0x0a, 0x73, 0x65, 0x6e, 0x74, 0x69, 0x6e, 0x65, 0x6c, 
                    0x0d, 0x0a, 0x24, 0x37, 0x0d, 0x0a, 0x6d, 0x61, 0x73, 0x74, 0x65, 0x72, 0x73, 0x0d, 0x0a };
            ns.Write(payload, 0, payload.Length);
            ns.Flush();
            var data = new byte[1024];
            ns.Read(data, 0, data.Length);
            var recv = ns.Read(data, 0, data.Length);
            ns.Close();
            server.Close();
            return ParseResponse(data);
        }
