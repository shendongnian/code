    protected virtual void Dispose(bool disposing)
    {
      try
      {
        if (!disposed)
        {
            if (disposing)
            {
                // Dispose managed resources.
            }    
        }
      }
      finally
      {       
        base.Dispose(disposing); 
      }
      disposed = true;    
    }
