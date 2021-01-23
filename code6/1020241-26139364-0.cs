    public static class ExceptionHandler
    {
        public static void Run(Action action)
        {
            try
            {
               a();
            }
            catch(Exception e)
            {
               //Do Something with your exception here, like logging
            }
        }
    }
