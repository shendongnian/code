    Process process = new Process();
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.FileName = "sd.exe";
    process.StartInfo.Arguments = string.Format("describe {0}", newChangelist);
    process.Start();
    
    // read strings from process.StandardOutput here
    process.WaitForExit();
