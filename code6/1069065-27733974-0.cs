    Process myProcess = new Process();
    ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(args[0], "spawn");
    myProcessStartInfo.UseShellExecute = false; // important!
    myProcessStartInfo.RedirectStandardOutput = true; // also important!
    myProcess.StartInfo = myProcessStartInfo;
    myProcess.Start();
 
    // Here we're reading the process output's first line:
    StreamReader myStreamReader = myProcess.StandardOutput;
    string myString = myStreamReader.ReadLine();
    Console.WriteLine(myString);
