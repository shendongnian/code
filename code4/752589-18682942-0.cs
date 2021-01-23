        /// <summary>
        /// Handles a TCP request.
        /// </summary>
        /// <param name="clientObject">The tcp client from the accepted connection.</param>
        protected void HandleTCPRequest(object clientObject)
        {
            TcpClient inClient = clientObject as TcpClient;
            TcpClient outClient = null;
            try
            {
                NetworkStream clientStream = inClient.GetStream();
                StreamReader clientReader = new StreamReader(clientStream);
                StreamWriter clientWriter = new StreamWriter(clientStream);
                // Read initial request.
                List<String> connectRequest = new List<string>();
                string line;
                while (!String.IsNullOrEmpty(line = clientReader.ReadLine()))
                {
                    connectRequest.Add(line);
                }
                if (connectRequest.Count == 0)
                {
                    throw new Exception();
                }
                string[] requestLine0Split = connectRequest[0].Split(' ');
                if (requestLine0Split.Length < 3)
                {
                    throw new Exception();
                }
                // Check if it is CONNECT
                string method = requestLine0Split[0];
                if (!method.Equals("CONNECT"))
                {
                    throw new Exception();
                }
                // Get host and port
                string requestUri = requestLine0Split[1];
                string[] uriSplit = requestUri.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (uriSplit.Length < 2)
                {
                    throw new Exception();
                }
                string host = uriSplit[0];
                int port = Int32.Parse(uriSplit[1]);
                // Connect to server
                outClient = new TcpClient(host, port);
                // Send 200 Connection Established to Client
                clientWriter.WriteLine("HTTP/1.0 200 Connection established\r\n\r\n");
                clientWriter.Flush();
                Logger.Debug("Established TCP connection for " + host + ":" + port);
                Thread clientThread =  new Thread(() => TunnelTCP(inClient, outClient));
                Thread serverThread = new Thread(() => TunnelTCP(outClient, inClient));
                clientThread.Start();
                serverThread.Start();
            }
            catch(Exception)
            {
                // Disconnent if connections still alive
                Logger.Debug("Closing TCP connection.");
                try
                {
                    if (inClient.Connected)
                    {
                        inClient.Close();
                    }
                    if (outClient != null && outClient.Connected)
                    {
                        outClient.Close();
                    }
                }
                catch (Exception e)
                {
                    Logger.Warn("Could not close the tcp connection: ", e);
                }
            }
        }
        /// <summary>
        /// Tunnels a TCP connection.
        /// </summary>
        /// <param name="inClient">The client to read from.</param>
        /// <param name="outClient">The client to write to.</param>
        public void TunnelTCP(TcpClient inClient, TcpClient outClient)
        {
            NetworkStream inStream = inClient.GetStream();
            NetworkStream outStream = outClient.GetStream();
            byte[] buffer = new byte[1024];
            int read;
            try
            {
                while (inClient.Connected && outClient.Connected)
                {
                    if (inStream.DataAvailable && (read = inStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        outStream.Write(buffer, 0, read);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Debug("TCP connection error: ", e);
            }
            finally
            {
                Logger.Debug("Closing TCP connection.");
                // Disconnent if connections still alive
                try
                {
                    if (inClient.Connected)
                    {
                        inClient.Close();
                    }
                    if (outClient.Connected)
                    {
                        outClient.Close();
                    }
                }
                catch (Exception e1)
                {
                    Logger.Warn("Could not close the tcp connection: ", e1);
                }
            }
        }
