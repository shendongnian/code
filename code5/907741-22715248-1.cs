            TcpClient client = new TcpClient("127.0.0.1", 13579);
            NetworkStream serverStream = client.GetStream();
            int totalBytesReceived = 0;
            int datacounter = 0;
            byte[] recived = new byte[256];
            StringBuilder stb = new StringBuilder();
            serverStream.ReadTimeout = 1500;
            try
            {
                while ((datacounter = serverStream.Read(recived, 0, 256)) > 0)
                {
                    totalBytesReceived += 256;
                    Console.WriteLine("RECIVED: {0}, {1}", datacounter, totalBytesReceived);
                    stb.Append(System.Text.Encoding.UTF8.GetString(recived, 0, datacounter));
                }
            }
            catch { Console.WriteLine("Timeout!"); }
