    private void startCMDtask()
    {
        var task = Task.Factory.StartNew(() => startCMD());
        cmdTask = task;
    }
    
    private async void startCMD()
    {
        try   { CMD.Start(); CMDrunning = true; } 
        catch { cmdErrOutput.Append("\r\nError starting cmd process."); 
                CMDrunning = false; }
        CMD.BeginOutputReadLine();
        CMD.BeginErrorReadLine();
        using (StreamWriter sw = CMD.StandardInput)
        {
            if (sw.BaseStream.CanWrite)
                do {  
                    try 
                    {
                        string cmd = cmdQueue.Dequeue();
                        if (cmd != null & cmd !="")  await sw.WriteLineAsync(cmd);
                    } 
                    catch { } 
                }   while (CMDrunning);
            try   { CMD.WaitForExit(); } 
            catch { cmdErrOutput.Append("WaitForExit Error.\r\n"); }
        }
    }
        
      
