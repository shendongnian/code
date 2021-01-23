    void MyMethod() 
    { 
       using (RILogManager.Default.TraceMethod(MethodBase.GetCurrentMethod()))
       {
          try
          {
          }
          catch(Exception e)
          {
              RILogManager.Default.SendException(e);
          }
       }    
    }
