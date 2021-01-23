	public void Start()
	{
		ThrowIfDisposed();
		if (_TcpServer != null;)
			_TcpServer.Stop();
		_TcpServer = new TcpListener(IPAddress.Any, _PortNumber);
		_TcpServer.Start();
		_TcpServer.BeginAcceptTcpClient(OnClientConnected, _TcpServer);
		_Log.Info("Start listening for incoming connections on " + _TcpServer.LocalEndpoint + ".");
	}
	private void OnClientConnected(IAsyncResult asyncResult)
	{
		var tcpServer = (TcpListener)asyncResult.AsyncState;
		IPAddress address = IPAddress.None;
		try
		{
			if (tcpServer.Server != null
				&& tcpServer.Server.IsBound)
				tcpServer.BeginAcceptTcpClient(OnClientConnected, tcpServer);
			using (var client = tcpServer.EndAcceptTcpClient(asyncResult))
			{
				address = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
				_Log.Debug("Client connected from address " + address + ".");
				var formatter = new BinaryFormatter();
				var informations = new MyInformation()
				{
                    // Initialize properties with desired values.
				};
				var stream = client.GetStream();
				formatter.Serialize(stream, description);
				_Log.Debug("Sucessfully serialized information into network stream.");
			}
		}
		catch (ObjectDisposedException)
		{
			// This normally happens, when the server will be stopped
			// and their exists no other reliable way to check this state
			// before calling EndAcceptTcpClient().
		}
		catch (Exception ex)
		{
			_Log.Error(String.Format("Cannot send instance information to {0}.", address), ex);
		}
	}
