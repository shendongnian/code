    const string filename = @"D:\Public\Temp\temp.txt";
    // Set timeout to the time you want to quit (one minute from now)
    var timeout = DateTime.Now.Add(TimeSpan.FromMinutes(1));
    while (!File.Exists(filename))
    {
        if (DateTime.Now > timeout)
        {
            Logger("Application timeout; app_boxed could not be created; try again");
            Environment.Exit(0);
        }
        Thread.Sleep(TimeSpan.FromSeconds(1));
    }
