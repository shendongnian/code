Sample Code
    public override void Install(IDictionary stateSaver)
    {
        base.Install(stateSaver);
    
        Process process = new Process();
     
        ProcessStartInfo startInfo = new ProcessStartInfo();
        process.StartInfo = startInfo;
    
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardError = true;
        startInfo.FileName = "ConsoleApp.exe";
        process.Start();
    }
