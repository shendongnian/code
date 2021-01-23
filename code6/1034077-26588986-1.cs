	using System.Diagnostics;
...
    TimeSpan begin = Process.GetCurrentProcess().TotalProcessorTime;
    //what you want to control...
    TimeSpan end = Process.GetCurrentProcess().TotalProcessorTime;
	Console.WriteLine("Process.TotalProcessor measured time: {0} ms", (end - begin).TotalMilliseconds);
	
