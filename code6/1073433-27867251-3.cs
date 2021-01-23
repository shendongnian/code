    public static class ExcetpionHandler
    {
        public static void StdTryCatch(this IExceptionHandler instance, Action act)
        {
            try
            {
                act();
            }
            catch (Exception ex)
            {
                instance.StdException(ex);
            }
        }
    
    }
