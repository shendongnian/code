    private void your_ExitedHandler(object sender, System.EventArgs e) {
        /* ... */
        Process p = new Process();
        p.StartInfo.FileName = "your\\new\\path\\bin.exe";
        p.Start();
        /* ... */
    }
    
    public void yourFunction() {
        /* ... */
        Process p = new Process();
        p.StartInfo.FileName = path;
        p.EnableRaisingEvents = true;
        p.Exited += new EventHandler(your_ExitedHandler);
        p.Start();
        /* ... */
    }
