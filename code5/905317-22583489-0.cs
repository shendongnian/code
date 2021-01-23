	try
	{	        
		var processes = Process.GetProcesses();
		foreach (var process in processes)
		{
			Console.WriteLine(String.Format("{0} - {1}", process.Id, process.ProcessName));
			Console.WriteLine(process.MainModule.FileName);
		}
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message);
	}
