    Process process = new System.Diagnostics.Process();
    ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    startInfo.FileName = "cmd.exe";
    startInfo.Arguments = pingData;
    
    proc.StartInfo.RedirectStandardOutput = true; 
    string output = proc.StandardOutput.ReadToEnd();
    process.StartInfo = startInfo;
    process.Start();
    //Do the 'clipboard thing' with 'output' variable. Its your time :P
    
