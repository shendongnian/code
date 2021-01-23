     try
     {
         Application.Lock()
         Dataset ds = Application["myGlobalDataset] as Dataset;
          ......
      }
      finally
      {
          Application.UnLock()
      }
