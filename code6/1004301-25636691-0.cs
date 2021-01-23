    public static void LogMessage(string message)
        {
            TextWriter textWriter = new StreamWriter("download.log", true);
            textWriter.WriteLine(message);
            textWriter.Close();
        }
