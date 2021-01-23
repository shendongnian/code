	using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
	{
		client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 42424));
		client.Send(new byte[] {1, 2, 3}, SocketFlags.None);
		byte[] bt = new byte[256];
		client.Receive(bt, 256, SocketFlags.None);
	}
