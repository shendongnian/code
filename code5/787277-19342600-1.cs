    Something x = null;
    try 
    {
       x = new Something();
    }
    finally
    {
       if ((x != null) && (x is IDisposable))
          ((IDisposable)x).Dispose();
    }
    
