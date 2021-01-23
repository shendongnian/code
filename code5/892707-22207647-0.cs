		public static void Main(string[] args)
		{
			// sample listener
			var listener = new TcpListener(IPAddress.Any, 1334);
			listener.Start ();
			listener.BeginAcceptTcpClient ((ar) => 
				{
					var l = ar.AsyncState as TcpListener;
					if (l != null)
					{
						var bytes = Encoding.UTF8.GetBytes ("Hello World!");
						l.EndAcceptTcpClient (ar).GetStream ().Write (bytes, 0, bytes.Length);
					}
				}, 
				listener);
			// async client
			var client = new TcpClient ();
			var connection = client.ConnectAsync("localhost", 1334);
			connection.Wait ();
			if (!connection.IsFaulted)
			{
				var buffer = new byte[1024];
				var res = client.GetStream ().ReadAsync (buffer, 0, buffer.Length);
				res.Wait ();
				if (!res.IsFaulted)
				{
					Console.WriteLine (Encoding.UTF8.GetString (buffer));
				}
			}
		}
