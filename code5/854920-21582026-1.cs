    public static class Logger
        {
            static TextLogTraceListener textLogTraceListener = new TextLogTraceListener("Trace.log");
    
            public static void CloseWriter()
            {
                textLogTraceListener.Close();
            }
    
            public static void Error(string message, string module)
            {
                WriteEntry(message, "ERROR", module);
            }
    
            public static void Error(Exception ex, string module)
            {
                WriteEntry(ex.Message + Environment.NewLine + ex.StackTrace, "ERROR", module);
            }
    
            public static void Warning(string message, string module)
            {
                WriteEntry(message, "WARNING", module);
            }
    
            public static void Info(string message, string module)
            {
                WriteEntry(message, "INFO", module);
            }
    
            private static void WriteEntry(string message, string type, string module)
            {
                textLogTraceListener.WriteLine(string.Format("[{0}] [{1}] [{2}] {3}",
                                      DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                      type,
                                      module,
                                      message));
            }
        }
