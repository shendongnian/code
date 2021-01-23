     static int processCount = 0;               //ADD
     static void runSingleFile(string execFile, string commandArgs)
     {
        processCount += 1;                       //ADD
        Process processToRun = new Process();
        processToRun.StartInfo.FileName = execFile;
        processToRun.StartInfo.Arguments = commandArgs;
        processToRun.StartInfo.UseShellExecute = false;
        processToRun.StartInfo.RedirectStandardOutput = true;
        processToRun.OutputDataReceived += outputRedirection;
        processToRun.EnableRaisingEvents = true;  //ADD
        processToRun.Exited += processExited;     //ADD
        processToRun.Start();
        Console.WriteLine("");
        processToRun.BeginOutputReadLine();
     }
     static void processExited(object sender, EventArgs e)
     {
         processCount -= 1;
     }
