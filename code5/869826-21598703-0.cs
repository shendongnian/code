    static void Main(string[] args)
		{
			
			IPAddress localAdd = IPAddress.Parse(SERVER_IP);
			TcpListener listener = new TcpListener(IPAddress.Any, PORT_NO);
			Console.WriteLine("Krenuo sa radom...");
			listener.Start();
			while (true)
			{
				
				TcpClient client = listener.AcceptTcpClient();
				
				NetworkStream nwStream = client.GetStream();
				byte[] buffer = new byte[client.ReceiveBufferSize];
				
				int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
				
				string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
				Console.WriteLine("Primljeno : " + dataReceived);
				
				Console.WriteLine("Dobijena poruka na serveru : " + dataReceived);
				nwStream.Write(buffer, 0, bytesRead);
				Console.WriteLine("\n");
				client.Close();
			}
			listener.Stop();
		}
