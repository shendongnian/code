    try
    {
           Process myProcess = new Process();
           // Start a process to print a file and raise an event when done.
           myProcess.StartInfo.FileName = fileName;
           myProcess.StartInfo.Verb = "Print";
           myProcess.EnableRaisingEvents = true;
           myProcess.Exited += new EventHandler(myProcess_Exited);
           myProcess.Start();
     }
     catch (Exception ex)
     {
         Console.WriteLine("An error occurred trying to print \"{0}\":" + "\n" + ex.Message, fileName);
         return;
     }
    // Handle Exited event and display process information. 
    private void myProcess_Exited(object sender, System.EventArgs e)
    {
            eventHandled = true;
            Console.WriteLine("Exit time:    {0}\r\n" +
                "Exit code:    {1}\r\nElapsed time: {2}", myProcess.ExitTime, myProcess.ExitCode, elapsedTime);
    }
