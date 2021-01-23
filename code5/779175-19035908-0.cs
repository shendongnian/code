	public class SocketEventArgs : EventArgs
	{
		public Socket Socket { get; private set; }
 
		public SocketEventArgs(Socket socket)
		{
			Socket = socket;
		}
	}
 
	/// <author>Jeroen van Langen</author>
	/// <source>http://http://csharp.vanlangen.biz/network-programming/async-sockets/easysocketlistener/</source>
	public class EasySocketListener : IDisposable
	{
		private Socket _socket;
 
		public void Start(int port)
		{
			_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_socket.Bind(new IPEndPoint(IPAddress.Any, port));
			_socket.Listen(8);
 
			StartAccepting();
		}
 
		private void StartAccepting()
		{
			try
			{
				_socket.BeginAccept((asyncResult) =>
				{
					try
					{
						Socket clientSocket = _socket.EndAccept(asyncResult);
						if (OnSocketAccept != null)
							OnSocketAccept(this, new SocketEventArgs(clientSocket));
 
						StartAccepting();
					}
					catch { }
				}, null);
			}
			catch { }
		}
 
		public void Dispose()
		{
			if (_socket != null)
			{
				_socket.Dispose();
				_socket = null;
			}
		}
 
		public event EventHandler<SocketEventArgs> OnSocketAccept;
	}
