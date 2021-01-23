        private static void RestartService(string remoteMachine, string serviceName, string userName, string password)
        {
            using (new NetworkConnection($"\\\\{remoteMachine}", new NetworkCredential(userName, password)))
            {
                Process.Start("CMD.exe", $"/C sc \\\\{remoteMachine} stop \"{serviceName}\"&sc \\\\{remoteMachine} start \"{serviceName}\"");
            }
        }
