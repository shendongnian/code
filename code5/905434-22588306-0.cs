    public static int runAdb(string args, out string output)
    {
        adbProc.StartInfo.Arguments = args;
        adbProc.Exited += new EventHandler(ProcessExitHandler);
        adbProc.Start();
    
        // Read all output into string output
        output = adbProc.StandardOutput.ReadToEnd();        
    }
    
    private void ProcessExitHandler(object sender,EventArgs args)
    {
    
    //Your process exited and now do whatever you want.
    
    }
