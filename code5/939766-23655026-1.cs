    public void LogMessageToFile(string message)
    {
        // Get the physical path corresponding to the root folder of your site plus APP_DATA
        string appData = Server.MapPath("~/APP_DATA");
        // Create the log file name
        string logFile = Path.Combine(appData, "ErrorLog.txt");
        // Append to the log file and close/dispose the stream
        using(StreamWrite aw = new StreamWriter(logFile, true))
        {
            sw.WriteLine(message);
        }
    }
