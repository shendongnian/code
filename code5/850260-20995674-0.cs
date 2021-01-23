      try
      {
          Application.Run(new Form()) ; 
      }
      catch(Exception ex)
      {
         Log(ex) ; 
      }
      void Log(Exception ex)
      {
          string stackTrace = ex.StackTrace ; 
          File.WriteAllText(youFilePathHere, stackTrace) ; // path of file where stack trace will be stored.
      }
