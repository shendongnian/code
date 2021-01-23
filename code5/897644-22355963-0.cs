            while (true)
            {
                    Socket client = server.AcceptSocket();
                    Console.WriteLine("Activity...");
                    IPEndPoint clientAddress = (IPEndPoint) client.RemoteEndPoint;
                    Console.WriteLine("Accepted client: {0}:{1}", clientAddress.Address, clientAddress.Port);
                    client.Close();
                    Console.WriteLine("Closed connection to: {0}:{1}", clientAddress.Address, clientAddress.Port);
            }
