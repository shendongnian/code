    public string WrapFunc(Dictionary<string, string> parameter)
    {
        //Check for required params
        bool hasAllParams = true;
        hasAllParams = CheckParam(parameter, "Param1") && hasAllParams;
        //hasAllParams = CheckParam(parameter, "Param2") && hasAllParams; etc.
        if (hasAllParams)
        {
            //proceed normally
            response = "SUCCESS"; //might be worth making it a const
        }
        else
        {
            response = "FAILURE";            
        }
        return response;
    }
    private bool CheckParam(Dictionary<string, string> parameters, string paramName)
    {
        if (!parameters.ContainsKey(paramName) || string.IsNullOrEmpty(parameters[paramName]))
        {
            LogRequiredParameterError(paramName);
            return false;
        }
        return true;
    }
