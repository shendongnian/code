        Process process = new Process();
        // Stop the process from opening a new window
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        // Setup executable and parameters
        process.StartInfo.FileName = args[0];
        // Go
        process.Start();
        process.WaitForExit();
