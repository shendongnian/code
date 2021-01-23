    private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
    {
        timer1.Enabled = true;
        timer1.Start();
        //patikrinimas();
    }
    private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
    {
        timer1.Enabled = true;
        timer1.Start();
        //patikrinimas();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        patikrinimas();
    }
