    Process[] p = Process.GetProcessesByName("YourProcess");
	foreach (ProcessThread thread in p[0].Threads)
	{
		Console.WriteLine(thread.Id);
	}
