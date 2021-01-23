    public void RunProcess(string FileName, string Arguments, bool EventWhenExit )
    {
        process = new Process();
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += new DataReceivedEventHandler(OnDataReceivedEvent);
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.LoadUserProfile = false;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.FileName = FileName; // Gets or sets the application or document to start.
        process.StartInfo.Arguments = Arguments;//Gets or sets the set of command-line arguments to use when starting the application      
        Thread.Sleep(1000);
        if (EventWhenExit)
        {
            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(myprocess_Exited);/*New line */
            
        }
        
        process.Start();
        process.BeginOutputReadLine();
        PID = process.Id;
    }
    private void myprocess_Exited(object sender, EventArgs e)
    {
        process.Refresh();
        Thread.Sleep(2000);
        onProcessEnd(this, "ENDOF " + Proc.ToString());
        Console.WriteLine("Process exsiting ");
    }
    private void OnDataReceivedEvent(object sender, DataReceivedEventArgs e)
    {
        string OutputFromProcess = e.Data;
        //fire event to event handler class for further use
        onDataOutputFromProcess(this, OutputFromProcess, Proc.ToString());
    }
