    void Main()
    {
        StringBuilder sb = new StringBuilder();
        var pSpawn = new Process
        {
             StartInfo = 
             { 
                WorkingDirectory = @"D:\temp", 
                FileName = "cmd.exe", 
                Arguments ="/c dir /b", 
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false
             }
        };
        
        
        pSpawn.OutputDataReceived += (sender, args) => sb.AppendLine(args.Data);
        pSpawn.Start();
        pSpawn.BeginOutputReadLine();
        pSpawn.WaitForExit();
        Console.WriteLine(sb.ToString());
    }
