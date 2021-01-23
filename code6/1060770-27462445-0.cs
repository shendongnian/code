    public void run()
        {
            while (running)
            {
                if (ClientPool == null)
                    continue;
                foreach (Client c in ClientPool)
                {
                    NetworkStream networkStream = c.getTcpClient().GetStream();
                    if (networkStream.CanRead)
                        handleDownStream(c, networkStream);
                    handleUpstream(c, networkStream);
                }
            }
        }
        public void handleDownStream(Client c, NetworkStream networkstream)
        {
            if (networkstream.DataAvailable == false)
                return;
            try
            {
                networkstream.Read(bytesFrom, 0, (int)c.getTcpClient().ReceiveBufferSize);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                Console.WriteLine("Message From: " + c.getClientIp() + " : " + dataFromClient);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }
        }
        public void handleUpstream(Client c, NetworkStream networkstream)
        {
            if (c.getTimeSinceLastMessage() > 30000 && c.getPinged())
            {
                Console.WriteLine("Removing Client From Pool, " + c.getClientIp());
                removeClientFromPool(c);
                return;
            }
            if (c.getTimeSinceLastMessage() > 15000 && c.getPinged() == false)
            {
                Console.WriteLine("Sending ping to Client, " + c.getClientIp());
                c.switchPinged();
                bytesToSend = Encoding.ASCII.GetBytes("ping");
                networkstream.Write(bytesToSend, 0, bytesToSend.Length);
                networkstream.Flush();
                bytesToSend = null;
            }
        }
