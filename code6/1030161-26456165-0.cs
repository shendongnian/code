    var processes = Process.GetProcessByName("AppName");
    foreach (var p in processes)
    {
        if (p != Process.GetCurrentProcess())
           p.CloseMainWindow(); 
    }
