    public static class WriteLineHelper
    {
        public static void WriteLine(string message,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null)
        {
            Console.WriteLine(string.Format("[{0}][{1}] : {2}, caller, lineNumber, message);
        }
    }
