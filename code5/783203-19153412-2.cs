    try
    {
         Process myProcess = new Process();
         myProcess.StartInfo.FileName = "notepad.exe";
	     myProcess.StartInfo.Arguments = @"C:\PathToYourFile";
         myProcess.EnableRaisingEvents = true;
         myProcess.Exited += new EventHandler(myProcess_Exited);
         myProcess.Start();
     }
     catch (Exception ex)
     {
         //Handle ERROR
         return;
     }
    // Handle Exited event and display process information. 
    private void myProcess_Exited(object sender, System.EventArgs e)
    {
         eventHandled = true;
         Console.WriteLine("Exit time:    {0}\r\n" +
                "Exit code:    {1}\r\nElapsed time: {2}", myProcess.ExitTime, myProcess.ExitCode, elapsedTime);
    }
