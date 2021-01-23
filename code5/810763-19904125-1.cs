    static void RunServer()
            {
                List<string> clientIP = new List<string>();
                List<string> clientNicks = new List<string>();
                string responseHandshake = "hello";
                Int32 serverPort = 1336;
                IPAddress machineIP = IPAddress.Parse(GetIP());
                Console.Clear();
                Console.WriteLine(" - Starting IlanChat server on IP {0}", machineIP);
                TcpListener server = null;
                server = new TcpListener(machineIP, serverPort);
                server.Start();
                Byte[] buffer = new Byte[256];
                String data = null;
                Console.WriteLine("Successfully started IlanChat server!");
                while (true) // first alpha - only one user at a time
                {
                    Console.WriteLine();
                    Console.WriteLine("Waiting for connections..");
                    TcpClient client = server.AcceptTcpClient();
    
                    Task.Run(() => RunClient(client));
                }
            }
    
            static void RunClient(TcpClient client)
            {
                Byte[] buffer = new Byte[256];
                Console.WriteLine("User connecting..");
                Console.WriteLine("Receiving handshake data..");
                String data = null;
                string responseHandshake = "hello";
    
                NetworkStream stream = client.GetStream();
                int i;
                while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(buffer, 0, i);
                    Console.WriteLine("Received handshake data: {0}", data);
                    Console.WriteLine("Processing data.."); // sample handshake: - HANDSHAKE:nick:ip
                    string tempNick = data.Replace("HANDSHAKE:", "");
                    string[] userDetails = tempNick.Split(':'); // should store to 0:nick, 1:ip
                    Console.WriteLine("Received client nick: {0}", userDetails[0]);
                    Console.WriteLine("Received client IP: {0}", userDetails[1]);
                    break;
                }
                Thread.Sleep(1100); // sleep
                buffer = System.Text.Encoding.ASCII.GetBytes(responseHandshake);
                Console.WriteLine("Sending response handshake..");
                stream.Write(buffer, 0, buffer.Length);
            }
