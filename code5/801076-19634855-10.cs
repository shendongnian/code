    void StartBatchFile(int arg)
    {
        var p = new Process();
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.Arguments = string.Format(@"/C demo.bat {0}", arg);
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.CreateNoWindow = true;
        p.OutputDataReceived += ConsumeData;
        try
        {
            p.Start();
            p.BeginOutputReadLine();
            p.WaitForExit();
        }
        finally
        {
            p.OutputDataReceived -= ConsumeData;
        }
    }
