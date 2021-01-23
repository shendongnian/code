    public static class LogWriter
    {
        // we keep a static reference to the StreamWriter so the stream stays open
        // this could be closed when not needed, but each open() takes resources
        private static StreamWriter writer = null;
        private static string LogFilePath = null;
        public static void Init(string FilePath)
        {
            LogFilePath = FilePath;
        }
        public static void WriteLine(string LogText)
        {
            // create a writer if one does not exist
            if(writer==null)
            {
                writer = new StreamWriter(File.Open(LogFilePath,FileMode.OpenOrCreate,FileAccess.Write,FileShare.ReadWrite));
            }
            try
            {
                // do the actual work
                writer.WriteLine(LogText);
            }
            catch (Exception ex)
            {
                // very simplified exception logic... Might want to expand this
                if(writer!=null)
                {
                    writer.Dispose();
                }
            }
        }
        // Make sure you call this before you end
        public static void Close()
        {
            if(writer!=null)
            {
                writer.Dispose();
                writer = null;
            }
        }
    }
