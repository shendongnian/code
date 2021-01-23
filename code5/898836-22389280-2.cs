    Process process = new System.Diagnostics.Process();
    ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    startInfo.FileName = "cmd.exe";
    startInfo.Arguments = pingData;
    //process.StartInfo.CreateNoWindow = true; 
    
    process.StartInfo.RedirectStandardOutput = true; 
    process.StartInfo = startInfo;
    process.Start();
    StreamReader stdOut = process.StandardOutput;  
    process.WaitForExit();  
    while (!stdOut.EndOfStream)  
    Console.WriteLine(stdOut.ReadLine()); 
    //Do the 'clipboard thing' with 'output' variable. Its your time :P
    
