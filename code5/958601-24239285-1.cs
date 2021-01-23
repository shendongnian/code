    Process process = new Process();
    process.EnableRaisingEvents = true;
    ...
    process.Exited += Process_Exited;
...
    private void Process_Exited(object sender, EventArgs e)
    {
        // First Process has completed - start second process here
    }
