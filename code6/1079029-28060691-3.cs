    try
    {
        using (var processGroupLimitJobMemory = new JobObject())
        using (var process = new Process())
        {
            try
            {
                process.StartInfo = new ProcessStartInfo
                {
                    WorkingDirectory = @"c:\Windows\System32",
                    FileName = "notepad.exe",
                    Arguments = null,// R# indicates this is a not null attribute
                    UseShellExecute = false
                };
                process.Start();
                processGroupLimitJobMemory.AttachProcess(process);
            }
            finally
            {
                if (!process.HasExited)
                {
                    try
                    {
                        Utilities.KillProcessTree(process);
                    }
                    catch (InvalidOperationException e)
                    {
                        // Trace
                    }
                    catch (ExternalException e)
                    {
                        // Trace
                    }
                }
            }
        }
    }
    catch (InvalidOperationException e)
    {
        return;
    }
