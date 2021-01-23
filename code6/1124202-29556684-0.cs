    public static int GetParameter(this Dictionary<string, string> context, string parameterName) 
    { 
       string stringParameter; 
       context.TryGetValue(parameterName, out stringParameter); 
       int parameter;
       int.TryParse(stringParameter, out parameter); 
       return parameter;
    }
    
    private int _personID;
    public void SomeFunction()
    {
       _personID = _classInstance.Context.GetParameter("PersonID");
    }
