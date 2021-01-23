    public static class Logs
    {
        static Logs()
        {
            _Writer = TextWriter.Synchronized(new StreamWriter(path));
        }
        private static TextWriter _Writer;
        static void LogLine(string line)
        {
            _Writer.WriteLine(line);
        }
    }
