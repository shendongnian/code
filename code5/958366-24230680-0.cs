    void TryGetValueFromJson<T>(ref T variableToFill, string[] possibleValueNames, Dictionary<string,object> info) 
    {
        Type outputType = typeof(T);
        foreach (string valueName in possibleValueNames) 
        {
            object value;
            if (info.TryGetValue(valueName, out value)) 
            {
                variableToFill = (T)Convert.ChangeType(value, outputType);
                break;
            }
        }
    }
