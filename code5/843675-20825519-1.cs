    {
       DisposableTest obj = null;
       try
       {
           obj = new DisposableTest();
           // some code throwing exception here.
       }
       finally
       {
          obj.Dispose();
       }
    }
