    void Login(string pathtofile)
    {
        Process process = new Process();
        process.StartInfo.FileName = pathtofile;
        process.EnableRaisingEvents = true;
        process.Exited += new EventHandler(process_Exited);
        process.Start(); 
    }
    void process_Exited(object sender, EventArgs e)
    {
        Process p = (Process)sender;
        int exitCode = p.ExitCode;
    }
