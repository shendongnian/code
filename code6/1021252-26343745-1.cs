	using System.Diagnostics;
	/// <summary>
	/// Reconnect all displays.
	/// </summary>
	public void ReconnectDisplays()
	{
		DisplayChanger.Start();
	}
	private static Process DisplayChanger = new Process
	{
		StartInfo =
		{
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden,
			FileName = "DisplaySwitch.exe",
			Arguments = "/extend"
		}
	};
	
