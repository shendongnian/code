	static void Main(string[] args)
	{
		IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000);
		using ( TcpClient client = new TcpClient() )
		{
			client.Connect(serverEndPoint);
			using ( NetworkStream clientStream = client.GetStream() )
			{
				byte[] buffer = Encoding.ASCII.GetBytes("Hello Server!");
				clientStream.Write(buffer, 0, buffer.Length);
			}
		}
	}
