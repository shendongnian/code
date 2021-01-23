        public static void TestCommands()
        {
            var command = "WebserviceClient.exe";
            ExecuteCommand(command, 5000);
            var command = "WebserviceClient2.exe";
            ExecuteCommand(command, 5000);
        }
        public static int ExecuteCommand(string command, int timeout)
        {
            var processInfo = new ProcessStartInfo(command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = @"C:\\",
            };
            var process = Process.Start(processInfo);
            process.WaitForExit(timeout);
            var exitCode = process.ExitCode;
            process.Close();
            return exitCode;
        } 
