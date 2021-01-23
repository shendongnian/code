    {
       DisposableTest obj = new DisposableTest();
       try
       {
           // some code throwing exception here.
       }
       finally
       {
          obj.Dispose();
       }
    }
