    var aaaParameter = parameterModel.Parameters.Single(p => p.Index == "AAA");
    if (aaaParameter.ParameterType == typeof(bool))
    {
        ...
    }
    else if (aaaParameter.ParameterType == typeof(string))
    {
        ...
    }
