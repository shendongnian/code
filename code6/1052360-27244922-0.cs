	public void GetInformationAsync(IPAddress ipAddress)
	{
		_Log.Info("Start retrieving informations from address " + ipAddress + ".");
		var tcpClient = new TcpClient();
		tcpClient.BeginConnect(ipAddress, _PortNumber, OnTcpClientConnected, tcpClient);
	}
	private void OnTcpClientConnected(IAsyncResult asyncResult)
	{
		try
		{
			using (var tcpClient = (TcpClient)asyncResult.AsyncState)
			{
				tcpClient.EndConnect(asyncResult);
				var ipAddress = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address;
				var stream = tcpClient.GetStream();
				stream.ReadTimeout = 5000;
				_Log.Debug("Connection established to " + ipAddress + ".");
				var formatter = new BinaryFormatter();
				var information = (MyInformation)formatter.Deserialize(stream);
				_Log.Info("Successfully retrieved information from address " + ipAddress + ".");
				InformationAvailable.FireEvent(this, new InformationEventArgs(information));
			}
		}
		catch (Exception ex)
		{
			_Log.Error("Error in retrieving informations.", ex);
			return;
		}
	}
