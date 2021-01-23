    private void IHazAProcess()
    {
        Process process = new Process();
        process.StartInfo.FileName = "ccleaner.exe";
        process.EnableRaisingEvents = true;
        process.Exited += process_Exited;
        process.Start();
    }
    private void process_Exited(object sender, EventArgs e) {
        // Do whatever you want when it exited
    }
