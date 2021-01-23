    bool processComplete = false;
    Process process = new Process();
    private void Start()
    {
        process.StartInfo.FileName = "path of wget";
        process.StartInfo.Arguments = "arguments for downloading images";
        process.EnableRaisingEvents = true;
        process.Exited += Process_Complete;
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hide;            
        process.Start();
    }
    private void Process_Complete(object sender, EventArgs e)
    {
        process.Exited -= Process_Complete;
        processComplete = true;
    }
