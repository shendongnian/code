	private void HandleClientComm(object client)
	{
		using ( TcpClient tcpClient = (TcpClient) client )
		{
			EndPoint remoteEndPoint = tcpClient.Client.RemoteEndPoint;
			try
			{
				using ( BinaryReader reader = new BinaryReader(tcpClient.GetStream(), Encoding.ASCII) )
				{
					for (;;)
					{
						string message = reader.ReadString();
						Console.WriteLine(message);
					}
				}
			}
			catch (EndOfStreamException ex)
			{
				Console.WriteLine("Client at IP address {0} closed the connection.", remoteEndPoint);
			}
			catch (Exception ex)
			{
				string formatString = "Client IP address {2}, {0}: {1}";
				do
				{
					Console.WriteLine(formatString, ex.GetType(), ex.Message, remoteEndPoint);
					ex = ex.InnerException;
					formatString = "\tInner {0}: {1}";
				}
				while (ex != null);
			}
		}
	}
