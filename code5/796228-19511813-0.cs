    public class SimpleLogger
    {
        private static DateTime lastLog;
        public static void WriteLine(object value)
        {
            WriteLine((value == null) ? string.Empty : value.ToString());
        }
        
        public static void WriteLine(string format)
        {
            WriteLine("{0}", format);
        }
        
        public static void WriteLine(string format, [NotNull] params object[] values)
        {
    #if DEBUG
            var formatted = String.Format(null, format, values);
            Debug.WriteLine("{0:hh:mm:ss.fff} [{1:hh:mm:ss.fff}] {2}", DateTime.Now, DateTime.Now - lastLog, formatted);
            lastLog = DateTime.Now;
    #endif
        }
    }
