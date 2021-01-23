    var processStartInfo = new ProcessStartInfo()
    {
        FileName = "cmd.exe",
        Arguments = "/c ping www.google.de",
        WindowStyle = ProcessWindowStyle.Hidden, //to hide the cmd window
        RedirectStandardOutput = true, //needed to redirect the output
        UseShellExecute = false
    };
    var process = new Process()
    {
        StartInfo = processStartInfo
    };
    if (process.Start())
    {
        while (!process.StandardOutput.EndOfStream)
        {
             var outputLine = process.StandardOutput.ReadLine();
             if(outputLine != null)
                 Debug.WriteLine(outputLine);
        }
    }
