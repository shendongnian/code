	private void checkMemory(Process process)
	{
		try
		{	        
			if (process != null)
			{
				Console.WriteLine("Memory Usage: {0} MB", process.WorkingSet64 / 1024 / 1024);
			}
		}
		catch (Exception exception)
		{
			Console.WriteLine(exception.Message);
		}
	}
