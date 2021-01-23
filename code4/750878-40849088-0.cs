    private void CheckLogs()
        {
            List<LogEntry> logs = Driver.Manage().Logs.GetLog(LogType.Browser).ToList();
            foreach (LogEntry log in logs)
            {
                Log(log.Message);
            }
        }
