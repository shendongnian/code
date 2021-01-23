    process_output = ""; // reset output before starting the process
    
    ProcessStartInfo startinfo = new ProcessStartInfo();
    startinfo.FileName = @"C:\Users\mehmetcan\Desktop\adt-bundle-windows-x86-20130917\sdk\platform-tools\adb.exe";
    startinfo.Arguments = @"devices";
    startinfo.RedirectStandardOutput = true;
    startinfo.RedirectStandardError = true;
    Process process = new Process();
    process.StartInfo = startinfo;
    process.EnableRaisingEvents = true; // enable exit event
    process.Exited += process_Exited; // called when the process exits
    
    process.OutputDataReceived += process_DataReceived;
    process.ErrorDataReceived += process_DataReceived;
    process.Start();
    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    
    // enable the next line if you want to wait for the process to terminate
    // before doing anything else (will freeze your UI if you have one)
    //process.WaitForExit();
