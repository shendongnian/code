    class Program
    {
        int port_server = 42424;
		Socket server_socket;
		public Program()
		{
			server_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			server_socket.Bind(new IPEndPoint(IPAddress.Any, port_server));
			server_socket.Listen(0);
		}
		public void Listen()
		{
			while (true)
			{
				var client = server_socket.Accept();
				var buffer = new byte[client.ReceiveBufferSize];
				client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), Tuple.Create(client, buffer));
			}
		}
		private void ReceiveCallback(IAsyncResult AR)
		{
			var state = (Tuple<Socket, byte[]>)AR.AsyncState;
			var client = state.Item1;
			var buffer = state.Item2;
			byte[] notifi = System.Text.Encoding.ASCII.GetBytes("Take this");
			client.Send(notifi);
			client.Close();
		}
		static void Main(string[] args)
		{
			var programm = new Program();
			programm.Listen();
		}
	}
