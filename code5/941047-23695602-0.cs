    private object lockObject = new object();
    private string fileName = Path.Combine(HttpRuntime.AppDomainAppPath, "LogFile.txt");
    public static void WriteErrorLog(string Message)
    {       
        lock(lockObject)
        {
            File.AppendAllLines(fileName, new string[] { Message + "\n" });
        }
    }
