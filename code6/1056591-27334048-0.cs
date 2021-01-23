    private void RunNotePad()
    {
        Process p1 = new Process("notepad.exe");
        p1.EnableRaisingEvents = true;
        //when process exit, excute ProcessExited function.
        p1.Exited += new EventHandler(ProcessExited);
        p1.Start();
    }
    public void ProcessExited(object source, EventArgs e)
    {
        //start to install a new version
    }
