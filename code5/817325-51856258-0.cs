    public int StartCheckDisc()
        {
            var process = new Process
            {
                StartInfo =
                {
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Normal,
                    FileName = "cmd",
                    Arguments = "/C chkdsk C:",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true
                }
            };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            var exitCode = process.ExitCode;
            var errorCode = process.StandardError.ReadToEnd();
            Log.Instance.Info(output);
            Log.Instance.Info(exitCode);
            Log.Instance.Info(errorCode);
            process.WaitForExit();
            return exitCode;
        }
