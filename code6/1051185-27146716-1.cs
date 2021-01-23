    public ParameterInfo[] ReturnInputParameters(string methodName)
    {
      //create an instance of the web service type
      //////////////to do/////////////////////////
      //get the name of the web service dynamically from the wsdl
      Object o = this.assem.CreateInstance("Service");
      Type service = o.GetType();
      ParameterInfo[] paramArr = null;
 
      //get the list of all public methods available in the generated //assembly
      MethodInfo[] infoArr = service.GetMethods();
           
      foreach (MethodInfo info in infoArr)
      {
      //get the input parameter information for the
      //required web method
        if (methodName.Equals(info.Name))
        {
          paramArr = info.GetParameters();
        }
      }
      return paramArr;
    }
 
