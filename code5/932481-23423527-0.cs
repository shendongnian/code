    public object BaseMethod(object[] userParameters,String FunctionName)
    {
      try
       {    
              Type thisType = this.GetType();
              MethodInfo theMethod = thisType.GetMethod(FunctionName);
              object returnObj;
              returnObj = theMethod.Invoke(this, userParameters);
              return returnObj;
       }
       catch (Exception e)
       {
                this.Logger(e.InnerException);
        }
    }
