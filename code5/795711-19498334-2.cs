    public static class ExceptionExtensions
    {
        public static void Log(this Exception ex)
        {
            clsLog.blnLogError(ex.GetType().Name, MethodBase.GetCurrentMethod().Name, String.Format("Error In {0}...", MethodBase.GetCurrentMethod().Name), ex.Message);
        }
    }
