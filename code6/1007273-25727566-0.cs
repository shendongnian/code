	var processName = "iexplore.exe";
	var connectoptions = new ConnectionOptions();
	connectoptions.Username = @"YourDomainName\UserName";
	connectoptions.Password = "User Password";
	string ipAddress = "192.168.206.53";
	ManagementScope scope = new ManagementScope(@"\\" + ipAddress + @"\root\cimv2", connectoptions);
	// WMI query
	var query = new SelectQuery("select * from Win32_process where name = '" + processName + "'");
	using (var searcher = new ManagementObjectSearcher(scope, query))
	{
		foreach (var process in searcher.Get())
		{
			process.InvokeMethod("Terminate", null);
		}
	}
	Console.ReadLine();
	
