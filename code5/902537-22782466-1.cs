    /// <summary>
    /// A static class for help with debugging and logging.
    /// </summary>
    public static class Log
    {
        public enum LogLevel {
            NONE = 0,
            FATAL,
            ERROR,
            INFO,
            DEBUG,
            VERBOSE,
            TRACE
        };
        private static StorageFileEventListener eventListener;
    #if DEBUG
        public static LogLevel logLevel = LogLevel.DEBUG;
    #else
        public static LogLevel logLevel = LogLevel.NONE;
    #endif
        /// <summary>
        /// Print out the debug message.
        /// </summary>
        /// <param name="msg">Message to print</param>
        /// <param name="level">Debug level of message</param>
        public async static void DebugPrint(string msg, LogLevel level)
        {
            if (ShouldLog(level))
            {
                msg = ComposeMessage(msg, level);
    #if DEBUG
                // Only do this in debug
                Debug.WriteLine(msg);
    #endif
    #if !DEBUG // Never crash in release build
                try
                {
    #endif
                    if (eventListener == null)
                    {
                        eventListener = new StorageFileEventListener();
                        eventListener.EnableEvents(LogEventSource.Log, EventLevel.LogAlways);
                        await eventListener.InitializeAsync();
                    }
                    LogEventSource.Log.Debug(msg);
    #if !DEBUG
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
    #endif
            }
        }
        /// <summary>
        /// Construc the formatted log message
        /// </summary>
        /// <param name="msg">Main message</param>
        /// <param name="level">Log level</param>
        /// <returns>Formated message</returns>
        private static string ComposeMessage(string msg, LogLevel level)
        {
            return DateTime.Now.ToString(@"M/d/yyyy hh:mm:ss.fff tt") + " [" + Environment.CurrentManagedThreadId.ToString("X4") + "] " + LevelToString(level) + " " + msg;
        }
        /// <summary>
        /// Get the string alias for a log level.
        /// </summary>
        /// <param name="level">The log level</param>
        /// <returns>String representation of the log level.</returns>
        private static string LevelToString(LogLevel level)
        {
            string res = "NOT FOUND";
            switch (level)
            {
                case LogLevel.NONE:
                    throw new Exception("You should not log at this level (NONE)");
                case LogLevel.FATAL: res = "FATAL"; break;
                case LogLevel.ERROR: res = "ERROR"; break;
                case LogLevel.INFO: res = "INFO"; break;
                case LogLevel.DEBUG: res = "DEBUG"; break;
                case LogLevel.VERBOSE: res = "VERBOSE"; break;
                case LogLevel.TRACE: res = "TRACE"; break;
            }
            return res;
        }
        /// <summary>
        /// Check the passed log level against the current log level 
        /// to see if the message should be logged.
        /// </summary>
        /// <param name="level">Log level to check against</param>
        /// <returns>True is should be logeed otherwise false.</returns>
        private static bool ShouldLog(LogLevel level)
        {
            if (level <= logLevel)
                return true;
            else
                return false;
        }
    }
