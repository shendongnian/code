    public static class ExcetpionHandler
    {
        public static void StdTryCatch(this object instance, Action act)
        {
            try
            {
                act();
            }
            catch (Exception ex)
            {
                var method = instance.GetType().GetMethod("StdException");
                if (method != null)
                {
                    method.Invoke(instance, new object[] {ex});
                }
                else
                {
                    throw;
                }
            }
        }
    
    }
