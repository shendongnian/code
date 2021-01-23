	try
	{           
		var md5 = MD5.Create();
		var processes = Process.GetProcesses();
		foreach (var process in processes)
		{
			var md5Hash = md5.ComputeHash(Encoding.ASCII.GetBytes(process.ProcessName));
			var md5HashAsBase64 = Convert.ToBase64String(md5Hash);
			Console.WriteLine(String.Format("{0} - {1} - {2}", process.Id, process.ProcessName, md5HashAsBase64));
		}
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message);
	}
