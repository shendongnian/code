    public class AsyncServer
	{
		private const int Port = 9999;
		public void StartServer()
		{
			var thread = new Thread(Run) {IsBackground = true};
			thread.Start();
		}
		private void Run()
		{
			Console.WriteLine("Running");
			var tcpListener =  new TcpListener(IPAddress.Loopback, Port);
			tcpListener.Start();
			while (true)
			{
				Console.WriteLine("Before Accept");
				var state = new ServerState {WorkSocket = tcpListener.AcceptSocket()};
				Console.WriteLine("Before Recieve");
				Receive(state);
			}
		}
		private void Receive(ServerState state)
		{
			state.WorkSocket.BeginReceive(state.Buffer, 0, ServerState.BufferSize, 0, ReceiveCallBack, state);
		}
		private void ReceiveCallBack(IAsyncResult ar)
		{
			Console.WriteLine("ReceiveCallBack");
			var state = (ServerState) ar.AsyncState;
			try
			{
				int byteReceived= state.WorkSocket.EndReceive(ar);
				if (byteReceived > 0)
				{
					var receivedString = Encoding.UTF8.GetString(state.Buffer, 0, byteReceived);
					Console.WriteLine("Received: " + receivedString);
					var bytesToSend = Encoding.UTF8.GetBytes("Server Got --> " + receivedString);
					Array.Copy(bytesToSend, state.Buffer, bytesToSend.Length);
					state.WorkSocket.Send(state.Buffer, 0, bytesToSend.Length, SocketFlags.None);
					Array.Clear(state.Buffer, 0, state.Buffer.Length);
					Receive(state);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
		private class ServerState
		{
			public const int BufferSize = 1024;
			public readonly byte[] Buffer = new byte[1024];
			public Socket WorkSocket;
		}
