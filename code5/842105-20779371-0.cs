    IPAddress[] ipAdd = Dns.GetHostAddresses("192.168.1.38");
                IPAddress ipAddress = ipAdd[0];
                TcpListener serverSocket = new TcpListener(ipAddress, 8888);
                TcpClient clientSocket = default(TcpClient);
                int counter = 0;
                serverSocket.Start();
                notifyIcon.ShowBalloonTip(5000, "Server Notification", " >> Server Started.", wform.ToolTipIcon.Info);
                counter = 0;
                while (true)
                {
                    counter += 1;
                    clientSocket = serverSocket.AcceptTcpClient();
    
                    byte[] bytesFrom = new byte[10025];
                    string dataFromClient = null;
    
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    if (clientsList.ContainsKey(dataFromClient))
                    {
                        continue;
                    }
                    else
                    {
                        clientsList.Add(dataFromClient, clientSocket);
                    }
                    string onlineUsers = "";
                    foreach (DictionaryEntry item in clientsList)
                    {
                        onlineUsers += item.Key.ToString() + ";";
                    }
                    onlineUsers =  onlineUsers.Remove(onlineUsers.Length - 1);
                    Broadcast.BroadcastSend(dataFromClient + " joined. |" + onlineUsers, dataFromClient, ref clientsList, false, false);
    
                    notifyIcon.ShowBalloonTip(5000,"Client Notification", dataFromClient + " joined.", wform.ToolTipIcon.Info);
                    HandleClient client = new HandleClient();
                    client.StartClient(clientSocket, dataFromClient, clientsList, notifyIcon);
                }
