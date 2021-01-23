    if(exc != null)
    {
      if (exc.GetType() == typeof(SingletonException))
      {
          Response.Redirect(@"~/Settings/Index");
      }
    
      exc = exc.InnerException;
    }
