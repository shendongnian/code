    public static class TryCatchExtention
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    
        public static void WithTryCatch(this object theClass, Action theMethod) 
        {
            try
            {
                theMethod.Invoke();
            }
            catch (Exception ex)
            {
                log.Error("Error : {0} " + ex.Message);
                throw new ApplicationException("");
            }  
        }
    }
