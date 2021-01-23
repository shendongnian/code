    public static class ExceptionExtensions
    {
        public static void Log(this Exception ex)
        {
            var stackTrace = new StackTrace();
            var methodName = stackTrace.GetFrame(1).GetMethod().Name;
            clsLog.blnLogError(ex.GetType().Name, methodName, String.Format("Error In {0}...", MethodBase.GetCurrentMethod().Name), ex.Message);
        }
    }
