    static public MyThing Create(...)
    {
      var cleanupList = new List<IDisposable>();
      try
      {
        MyThing Result = new MyThing(cleanupList, ...); // private or protected constructor
      }
      finally
      {
        if (Result == null)
        {
          List<Exception> failureList = null;
          foreach (IDisposable cleaner in cleanupList)
          {
            try
            {
              cleaner.Dispose();
            }
            catch(Exception ex)
            {
              if (failureList == null)
                failureList = new List<Exception>();
              failureList.Add(ex);
            }
          }
          if (failureList != null)
            throw new FailedConstructorCleanupException(failureList);
        }
      }      
    }
