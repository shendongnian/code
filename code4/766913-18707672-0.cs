    Process proc = null;
    //Kill process after 3 seconds
    Task.Run(() =>
    {
        Task.Delay(3000).Wait();
                
        if(proc!=null && proc.HasExited==false) proc.Kill();
    });
    var psi = new ProcessStartInfo()
    {
        FileName = "ping.exe",
        Arguments = "-t 127.0.0.1",
        RedirectStandardOutput = true,
        UseShellExecute = false,
        CreateNoWindow = true,
    };
    proc = new Process();
    proc.StartInfo = psi;
    proc.OutputDataReceived += (s,e) =>
    {
        Console.WriteLine(e.Data);
    };
                        
    proc.Start();
    proc.BeginOutputReadLine();
    proc.WaitForExit();
    Console.WriteLine("**killed**");
