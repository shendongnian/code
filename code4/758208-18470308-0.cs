    using (proc = new Process()) {
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.CreateNoWindow = true;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.RedirectStandardError = true;
        proc.StartInfo.FileName = exe;
        // XXX: The all important working directory.
        proc.StartInfo.WorkingDirectory = new FileInfo(exe).Directory.FullName;
        proc.StartInfo.Arguments = args.GetCommandLine();
        proc.StartInfo.LoadUserProfile = false;
        proc.OutputDataReceived += ReadLineHandler;
        proc.ErrorDataReceived += ReadLineHandler;
        proc.Start();
        proc.PriorityClass = Properties.Settings.Default.priority;
        proc.BeginOutputReadLine();
        proc.BeginErrorReadLine();
        proc.WaitForExit();
    }
