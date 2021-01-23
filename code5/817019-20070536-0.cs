    public class LogManager
    {
        public void LogException(Exception exc,
                                [CallerMemberName] string memberName = "",
                                [CallerFilePath] string sourceFilePath = "",
                                [CallerLineNumber] int sourceLineNumber = 0)
        {
            Trace.WriteLine(string.Format("Date: {0}", DateTime.Now));
            Trace.WriteLine(string.Format("Exception: {0}", exc.Message));
            Trace.WriteLine(string.Format("Occured in: {0}", memberName));
            Trace.WriteLine(string.Format("source file path: {0}", sourceFilePath));
            Trace.WriteLine(string.Format("source line number: {0}", sourceLineNumber));
        }
    }
