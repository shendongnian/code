    var aaaParameter = parameterModel.Parameters.Single(p => p.Index == "AAA");
    switch (aaaParameter.ParameterType)
    {
        case (typeof(bool)):
            ...
        case (typeof(int)):
            ...
    }
    
