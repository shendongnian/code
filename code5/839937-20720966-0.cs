    public object MyWebServiceDLLMethod()
    {
      if(!File.Exists(MyPathToAppConfig))
      {
        throw new Exception("File not found.");
         return null;
      }
      //"real" code for the method goes here. 
    }
