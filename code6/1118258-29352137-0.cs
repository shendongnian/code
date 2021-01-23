	public JoystickProcess getClient(string client)
	{
		if (clientList.InvokeRequired)
		{
			if(shutdown)
                return null;
			return (JoystickProcess) Invoke(new Func<JoystickProcess>(() => getClient(client)));
		}
		else
		{
			JoystickProcess process;
			if (clientToDevice.TryGetValue(client, out process))
				return process;
			return null;
		}
	}
