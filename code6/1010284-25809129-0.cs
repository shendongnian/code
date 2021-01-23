	/// <summary>
	/// Requests a connection (association) to the specified wireless network.
	/// </summary>
	/// <remarks>
	/// The method returns immediately. Progress is reported through the <see cref="WlanNotification"/> event.
	/// </remarks>
	public void Connect(Wlan.WlanConnectionMode connectionMode, Wlan.Dot11BssType bssType, string profile)
	{
		Wlan.WlanConnectionParameters connectionParams = new Wlan.WlanConnectionParameters();
		connectionParams.wlanConnectionMode = connectionMode;
		connectionParams.profile = profile;
		connectionParams.dot11BssType = bssType;
		connectionParams.flags = 0;
		Connect(connectionParams);
	}
