    public static class ExceptionExtensions
    {
        public static void Log(this Exception ex)
        {
            var stackTrace = new StackTrace();
            var methodName = stackTrace.GetFrame(1).GetMethod().Name;
            var className = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
            clsLog.blnLogError(className, methodName, string.Format("Error In {0}...", methodName), ex.Message);
        }
    }
