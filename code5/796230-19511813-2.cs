    public class SimpleLogger
    {
        private static DateTime lastLog;
        [Conditional("DEBUG")]
        public static void WriteLine(object value)
        {
            WriteLine((value == null) ? string.Empty : value.ToString());
        }
        [Conditional("DEBUG")]
        public static void WriteLine(string format)
        {
            WriteLine("{0}", format);
        }
        [Conditional("DEBUG")]
        public static void WriteLine(string format, params object[] values)
        {
            var formatted = String.Format(null, format, values);
            Debug.WriteLine("{0:hh:mm:ss.fff} [{1:hh:mm:ss.fff}] {2}", DateTime.Now.ToUniversalTime(), DateTime.Now - lastLog, formatted);
            lastLog = DateTime.Now;
        }
    }
