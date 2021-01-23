    DataContext pContext = new DataContext()
    try
    {
       //do stuff here
    }
    finally
    {
       if(pContext!=null)
          ((IDisposable)pContext).Dispose();
    }
