    //Get Index of the opening parentheses
    int prIndex = cdLine.IndexOf("("); // 20
    
    //Cut the parameter code part
    string pmtrString = cdLine.Substring(prIndex + 1, cdLine.Length - 1); //"string name"
    
    //Use this line to check for number of parameters
    string[] Parameters = pmtrString.Split(',');
    
    // If it is 1 parameter only like in your example
    string[] ParameterParts = pmtrString.Split(' ');// "string", "name"
    string ParameterName = ParameterParts[ParameterParts.Length - 1];// "name"
    
    // The ParameterName is the variable containing the Parameter name
