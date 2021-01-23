    public static class Task
    {
          
        public static TResult TryCatch<TResult>(Func<TResult> methodDelegate)
        {
            try
            {
                return methodDelegate();
            }
            catch (Exception ex)
            {
                // .. exception handling ...
            }
            return default(TResult);
        }
    }
