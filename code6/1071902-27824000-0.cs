    try 
    {
      c = new myContext();
      Contract.Ensures ...
    }
    finally
    {
       c.Dispose();
    }
