        var processStartInfo = new ProcessStartInfo
        {
            FileName = @"C:\PuttyLocation",
            RedirectStandardOutput = true,
            UseShellExecute = false, // You have to set ShellExecute to false
            ErrorDialog = false
        };
        var process = Process.Start(processStartInfo);
        if (process == null)
        {
            return;
        }
        var reader = process.StandardOutput;
        while (!reader.EndOfStream)
        {
            // Read data..
        }
