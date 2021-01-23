	void RemoveSession()
	{
		var netEventSession = new ManagementClass("/root/standardcimv2:MSFT_NetEventSession").
			GetInstances().
			Cast<ManagementObject>().
			SingleOrDefault();
		if (netEventSession != null)
		{
			if ((byte)netEventSession["SessionStatus"] == 0)
			{
				netEventSession.InvokeMethod("Stop", null, null);
			}
			netEventSession.Delete();
		}
	}
