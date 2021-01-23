    public class Class
    {
        public Class(object arg)
        {
            try
            {
               ...
               throw new Exception("message");
               ...
            }
            catch
            {
                // This is just empty. By purpose.
            }
            finally
            {
                ...
            }
        }
    }
