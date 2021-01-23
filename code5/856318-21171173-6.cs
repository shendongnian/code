    try
    {
    }
    catch (Exception exception)
    {
         if (exception.GetType() == typeof(IOException))
         {
         }
         else if (exception.GetType() == typeof(DirectoryNotFoundException))
         {
         }
         else if (exception.GetType() == typeof(FileNotFoundException))
         {
         }
         else
         {
             log(exception);
             throw;
         }
    }
