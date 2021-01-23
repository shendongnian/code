    var sb = new StringBuilder();
    
    Process p = new Process();
    p.StartInfo = new new ProcessStartInfo();
    p.StartInfo.RedirectStandardOutput = true;
    p.StartInfo.RedirectStandardError = true;
    
    p.OutputDataReceived += (sender, args) => sb.AppendLine(args.Data);
    p.ErrorDataReceived += (sender, args) => sb.AppendLine(args.Data);
    p.StartInfo.UseShellExecute=false;
    
    p.Start();
    p.BeginOutputReadLine();
    p.BeginErrorReadLine();
    
    p.WaitForExit();
    // do whatever you need with the content of sb.ToString();
