    public void LogMessageToFile(string message)
    {
        string appData = Server.MapPath("~/APP_DATA");
        string logFile = Path.Combine(appData, "ErrorLog.txt");
        using(StreamWrite aw = new StreamWriter(logFile))
        {
            sw.WriteLine(message);
        }
    }
