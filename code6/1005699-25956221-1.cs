    Application application;
    Process[] processes = Process.GetProcessesByName(@"someapplication");
    if (processes.Length == 0)
      application = Application.Launch(@"someapplication");
    else
      application = Application.Attach(@"someapplication");
