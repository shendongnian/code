    do
    {
        string output = process.StandardOutput.ReadToEnd();
    
        buildWorker.ReportProgress(0, System.Environment.NewLine + output);
    }
    while (!process.HasExited);
