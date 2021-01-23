    private void ConsumeData(object sendingProcess, 
                DataReceivedEventArgs outLine)
    {
        if(!string.IsNullOrWhiteSpace(outLine.Data))
            Console.WriteLine(outLine.Data);
    }
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
