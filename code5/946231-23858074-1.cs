    var version = Environment.OSVersion.Version;
    if (version < new Version(6, 2))
    {
    	Console.WriteLine("This program isn't compatible with Windows 7 and older.");
    }
    else
    {
    	Console.WriteLine("This os is compatible");
    }
    Console.ReadLine();
