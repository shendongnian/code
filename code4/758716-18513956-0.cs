	private void OnReceive(object sender, SocketAsyncEventArgs e)
	{
	TOP:
		if (e != null)
		{
			int length = e.BytesTransferred;
			if (length > 0)
			{
				FireBytesReceivedFrom(Datagram, length, (IPEndPoint)e.RemoteEndPoint);
			}
			e.Dispose(); // could possibly reuse the args?
		}
		Socket s = Socket;
		if (s != null && RemoteEndPoint != null)
		{
			e = new SocketAsyncEventArgs();
			try
			{
				e.RemoteEndPoint = RemoteEndPoint;
				e.SetBuffer(Datagram, 0, Datagram.Length); // don't allocate a new buffer every time
				e.Completed += OnReceive;
				// this uses the fast IO completion port stuff made available in .NET 3.5; it's supposedly better than the socket selector or the old Begin/End methods
				if (!s.ReceiveFromAsync(e)) // returns synchronously if data is already there
					goto TOP; // using GOTO to avoid overflowing the stack
			}
			catch (ObjectDisposedException)
			{
				// this is expected after a disconnect
				e.Dispose();
				Logger.Info("UDP Client Receive was disconnected.");
			}
			catch (Exception ex)
			{
				Logger.Error("Unexpected UDP Client Receive disconnect.", ex);
			}
		}
	}
