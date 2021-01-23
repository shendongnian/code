	public void AcceptCallback(IAsyncResult result)
	{ 
		ConnectionInfo connection = new ConnectionInfo();
		try
		{
			long connection_number;
			Socket s;
			s = (Socket)result.AsyncState;
			connection.socket = s.EndAccept(result);
			connection.socket.Blocking = false;
			connection.Buffer = new byte[10000]; //1kb buffer minimum
			orionIP = ((IPEndPoint)connection.socket.RemoteEndPoint).Address.ToString();
			lock (connections) connections.Add(connection);
			IPHostEntry hostName = Dns.GetHostEntry(orionIP);
			machineName = hostName.HostName;
			lock (connections) connections.Add(connection);
			connection_number = Interlocked.Increment(ref connection_count);
			connection.socket.BeginReceive(connection.Buffer, 0, connection.Buffer.Length,
			SocketFlags.None, new AsyncCallback(ReceiveCallBack), connection);
		}
		catch (SocketException ex)
		{
			string path = "eventlogs.txt";
			File.WriteAllText(path, ex.ToString());
			CloseConnection(connection);
		}
		catch (Exception exp)
		{
			string path = "eventlogs.txt";
			File.WriteAllText(path, exp.ToString());
			CloseConnection(connection);
		}
		try
		{
			serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), result.AsyncState);
		}
		catch (Exception exception)
		{
			//failed to accept. shut down service.
		}
	}
