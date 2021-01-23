    var aaaParameter = parameterModel.Parameters.Single(p => p.Index == "AAA");
    if (aaaParameter.ParameterType is typeof(bool))
    {
        ...
    }
    else if (aaaParameter.ParameterType is typeof(string))
    {
        ...
    }
