    public static class Logger
    {
        public static LogFluent Log([CallerMemberName] string sourceMemberName = null)
        {
            return new LogFluent(sourceMemberName);
        }
    }
    public class LogFluent
    {
        private string _callerMemeberName;
        public LogFluent(string callerMamberName)
        {
            _callerMemeberName = callerMamberName;
        }
        public void Message(string message, params object[] messageArgs)
        {
            
        }
    }
