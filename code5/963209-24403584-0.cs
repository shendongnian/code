    private void BETAScanNetwork()
	{
		int contador = 0;
		for (int i = 1140; i <= 1160; i++)
		{
			UdpClient listener = null;
			bool incoming = false;
			try
			{
				listener = new UdpClient(i);
				var groupEp = new IPEndPoint(IPAddress.Any, i);
				listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 50);
				byte[] data = listener.Receive(ref groupEp);
				incoming = true;
				listener.Client.Shutdown(SocketShutdown.Both);
				listener.Client.Close();
				// Managing received data
			}
			catch (System.Net.Sockets.SocketException e)
			{
				var excp = e.SocketErrorCode;
				if (excp== SocketError.TimedOut)
				{
					continue;	
				}
				else
				{
					throw;
				}
			}
			finally
			{
				if (listener != null && !incoming)
				{
					listener.Client.Shutdown(SocketShutdown.Receive);
					listener.Close();
				}
			}
		}
	}
