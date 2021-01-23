    System.Diagnostics.Process p = new System.Diagnostics.Process();            
    
    p.StartInfo.FileName = "PATH TO YOUR FILE";
    p.StartInfo.UseShellExecute = false;
    p.StartInfo.Arguments = metalType + " " + graphHeight + " " + graphWidth;
    p.StartInfo.CreateNoWindow = true;
    p.StartInfo.RedirectStandardOutput = true;
    p.StartInfo.RedirectStandardError = true;              
    
    p.EnableRaisingEvents = true;
    p.Start();            
    svgText = p.StandardOutput.ReadToEnd();
    
    using(StreamReader s = p.StandardError)
    {
        string error = s.ReadToEnd();
        p.WaitForExit(20000);
    }
