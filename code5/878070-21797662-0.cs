            byte[] ba = new byte[1024];
            new Task(() => {
                Output("Going to listen to messages...");
                Socket listeningS = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // Listening to local address. You should listen to external IP for real server
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, port);
                listeningS.Bind((EndPoint)ep);
                // One and only client at a time :)
                listeningS.Listen(1);
                while (isRunning)
                {
                    // Accept client, receive data and send it back
                    Socket clientS = listeningS.Accept();
                    int total = clientS.Receive(ba, 0, ba.Length, SocketFlags.None);
                    total = clientS.Send(ba, 0, total, SocketFlags.None);
                    // Client will open new connection (but later it is possible to use same)
                    clientS.Shutdown(SocketShutdown.Both);
                    clientS.Close();
                }
            }).Start();
