    Process scriptProc = new Process();
    ProcessStartInfo info = new ProcessStartInfo();
    info.WorkingDirectory = appPath + @"external\";
    info.FileName = "Cscript.exe";
    info.Arguments = "UNLOCK.vbs" + employeeID;
    info.RedirectStandardError = true;
    info.RedirectStandardInput = true;
    info.RedirectStandardOutput = true;
    info.UseShellExecute = false;
    info.WindowStyle = ProcessWindowStyle.Hidden;
    scriptProc.StartInfo = info;
    scriptProc.Start();
    scriptProc.WaitForExit();
    bool exit = false;
    while (!scriptProc.StandardOutput.EndOfStream)
    {
        if (scriptProc.StandardOutput.ReadLine() == "Completed")
        {
            exit = true;
            break;
        }
    }
    if (exit == true)
    {
        getAllProcesses(true);
        Application.Exit();
    }
