    using (Process command = new Process())
    {        
        command.StartInfo = new ProcessStartInfo
        {
            CreateNoWindow = true,
            FileName = CommonStrings.RestartProccesCommand,
            Arguments = COMMAND1 && COMMAND2,
            LoadUserProfile = false,
            UseShellExecute = false,
            WindowStyle = ProcessWindowStyle.Hidden,
        };
        command.Start();
        command.WaitForExit(3000);
        exitCode = command.ExitCode;
    }
