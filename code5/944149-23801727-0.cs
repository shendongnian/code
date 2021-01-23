    Process[] allDumps = Process.GetProcessesByName("rtmpdump"); // get all rtmp processes
    if (allDumps.Any())
    {
        Process newestProcess = allDumps.OrderByDescending(x => x.StartTime).First(); // get the last one created     
        // Add the newly captured process to your list of processes for use later.
    }
