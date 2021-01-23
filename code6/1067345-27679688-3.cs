            using (var ns = new NetworkStream(socket))
            {
                int dataLength = 0;
                // reading the datalength
                for (int i = 0; i < 4; i++)
                {
                    while (!ns.DataAvailable)
                    {
                        System.Threading.Thread.Sleep(20);
                    }
                    dataLength = (dataLength << 8) + ns.ReadByte();
                }
                // reading the data
                byte[] buffer = new byte[1024];
                int bytesRead;
                using (var memoryStream = new MemoryStream())
                {
                    while (memoryStream.Length < dataLength)
                    {
                        while (!ns.DataAvailable)
                        {
                            System.Threading.Thread.Sleep(20);
                        }
                        bytesRead = ns.Read(buffer, 0, buffer.Length);
                        memoryStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
