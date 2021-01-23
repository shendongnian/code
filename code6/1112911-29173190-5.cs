    private static IEnumerable<LogFileDatabase> GetDatabasesFromLog(string logPath)
    {
        if (logPath == null) throw new ArgumentNullException("logPath");
        if (!File.Exists(logPath))
        {
            throw new FileNotFoundException(
                string.Format("logPath does not exist: {0}", logPath));
        }
        var databasesFromLog = new List<LogFileDatabase>();
        var fileLines = File.ReadAllLines(logPath)
            .Where(line => !string.IsNullOrWhiteSpace(line));
        var logFileDb = new LogFileDatabase();
        foreach (var fileLine in fileLines)
        {
            var dbNameIndex = fileLine.IndexOf(LogFileDatabase.NamePrefix);
            if (dbNameIndex > -1)
            {
                logFileDb.DbName = fileLine.Substring(
                    dbNameIndex + LogFileDatabase.NamePrefix.Length).Replace("\"", "");
                continue;
            }
            var serverIndex = fileLine.IndexOf(LogFileDatabase.ServerPrefix);
            if (serverIndex == -1) continue;
            logFileDb.Server = fileLine.Substring(
                serverIndex + LogFileDatabase.ServerPrefix.Length).Replace("\"", "");
            databasesFromLog.Add(logFileDb);
            logFileDb = new LogFileDatabase();
        }
        return databasesFromLog;
    }
