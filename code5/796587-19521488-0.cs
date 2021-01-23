    public static void WriteLine(string line)
    {
        lock (_lockObj)
        {
            File.AppendAllLines(pathToLogFile, line);
        }
    }
