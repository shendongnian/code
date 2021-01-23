    public static class ExceptionExtensions
    {
        public static void Log(this Exception ex)
        {
            var stackTrace = new StackTrace();
            var callingMethod = stackTrace.GetFrame(1).GetMethod();
            var methodName = callingMethod.Name;
            var className = callingMethod.DeclaringType.Name;
            clsLog.blnLogError(className, methodName, string.Format("Error In {0}...", methodName), ex.Message);
        }
    }
