    public string WrapFunc(Dictionary<string, string> parameter)
    {
        var response = "SUCCESS";
        var missingParams = new List<string>();
        //Check for required params
        if (parameter.ContainsKey("Param1") && !string.IsNullOrEmpty(parameter["Param1"]))
        {
            objWebAPiRequest.Param1 = parameter["Param1"];
        }
        else
        {
            // Add the name of the missing param to a list
            missingParams.Add("Param1");
        }
        if (missingParams.Any())
        {
            // Log all the missing parameters and set response to "FAILURE"
            foreach (var p in missingParams)
                LogRequiredParameterError(p);
            response = "FAILURE";
        }
        return response;
    }
    
    private void LogRequiredParameterError(string parameterName)
    {
        //Logging the missing parameter name to db
    }
