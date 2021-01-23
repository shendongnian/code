    private void ConsumeData(object sendingProcess, 
                DataReceivedEventArgs outLine)
    {
        Console.WriteLine(outLine.Data);
    }
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
