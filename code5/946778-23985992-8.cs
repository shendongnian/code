	private void HandleClientComm(object client)
	{
		using ( TcpClient tcpClient = (TcpClient) client )
		{
			EndPoint remoteEndPoint = tcpClient.Client.RemoteEndPoint;
		
			try
			{
				using (NetworkStream clientStream = tcpClient.GetStream() )
				{
					byte[] message = new byte[4096];
					for (;;)
					{
						//blocks until a client sends a message
						int bytesRead = clientStream.Read(message, 0, 4096);
						if (bytesRead == 0)
						{
							//the client has disconnected from the server
							Console.WriteLine("Client at IP address {0} closed connection.", remoteEndPoint);
							break;
						}
						//message has successfully been received
						Console.WriteLine(Encoding.ASCII.GetString(message, 0, bytesRead));
						// Console.ReadLine() has been removed.
						// See last section of the answer about why
 						// Console.ReadLine() was of little use here...
					}
				}
			}
			catch (Exception ex)
			{
				// Output exception information
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
