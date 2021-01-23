	internal static bool IsDomainController(string ServerName)
	{
		StringBuilder Results = new StringBuilder();
		try
		{
			ManagementObjectSearcher searcher =
				new ManagementObjectSearcher("\\\\" + ServerName + "\\root\\CIMV2",
				"SELECT * FROM Win32_ServerFeature WHERE ID = 10");
			foreach (ManagementObject queryObj in searcher.Get())
			{
				Results.AppendLine(queryObj.GetPropertyValue("ID").ToString());
			}
		}
		catch (ManagementException)
		{
			//handle exception
		}
		if (Results.Length > 0)
			return true;
		else
			return false;
	}
