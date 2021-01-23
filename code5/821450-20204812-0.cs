    Process process = Process.GetProcessesByName("myProcess").FirstOrDefault();
    if (process != null)
    {
        process.CloseMainWindow();
    }
