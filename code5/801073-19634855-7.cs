    void StartBatchFile(int arg)
    {
        var p = new Process();
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.Arguments = string.Format(@"/C demo.bat {0}", arg);
        p.OutputDataReceived += ConsumeData;
    
        try
        {
            p.Start();
            p.WaitForExit();
        }
        finally
        {
            p.OutputDataReceived -= ConsumeData;
        }
    }
