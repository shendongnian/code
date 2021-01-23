        private void ProcessClientThread(object clientObj)
        {
            Console.WriteLine("Client connected");
            ClientObject client = (ClientObject)clientObj;
            Socket clientSocket = client.ClientSocket;
            byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
            int receiveCount = 0;
            while (client.KeepProcessing)
            {
                try
                {
                    receiveCount = clientSocket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                    if (receiveCount == 0)
                        break; //the client has closed the stream
                    var ret = Encoding.ASCII.GetString(buffer, 0, receiveCount);
                    Console.WriteLine(ret);
                }
                catch (Exception ex)
                {
                    if (!client.KeepProcessing)
                        return;
                    Console.WriteLine(ex.Message);
                }
            }
            clientSocket.Close();
            _clients.Remove(client);
        }
