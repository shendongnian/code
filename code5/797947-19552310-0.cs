	// You'll need to reference "System.Management" for this to work...
	var server = "your server name";
	var scope = new System.Management.ManagementScope(@"\\" + server + @"\root\cimv2");
	scope.Connect();
	using (var searcher = new System.Management.ManagementObjectSearcher(scope,
			new System.Management.ObjectQuery(
				"Select Caption, IPAddress FROM Win32_NetworkAdapterConfiguration")))
	{
		using (var children = searcher.Get())
		{
			if (children.Count > 0)
			{
				foreach (var item in searcher.Get())
				{
					var nicName = item["Caption"];
					var ips = item["IPAddress"] as string[];
					if (ips != null)
					{
						Console.WriteLine(nicName);
						foreach (var ip in ips)
						{
							Console.WriteLine("   " + ip);
						}
					}
				}
			}
		}
	}
