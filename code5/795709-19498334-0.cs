    public class MyException : Exception
    {
        public void Log()
        {
            clsLog.blnLogError(this.GetType().Name, MethodBase.GetCurrentMethod().Name, String.Format("Error In {0}...", MethodBase.GetCurrentMethod().Name), objEx.Message);
        }
    }
