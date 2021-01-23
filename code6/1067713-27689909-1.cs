    public interface IConnection
    {
        void Connect();
    }
    public class TcpConnection : IConnection
	{
		public string Host { get; private set; }
		public int Port { get; private set; }
		
		private Socket _socket;
		
		public TcpConnection(string host, int port)
		{
			Host = host;
			Port = port;
		}
		
		public void Connect()
		{
			_socket = new Socket(...);
		}
	}
