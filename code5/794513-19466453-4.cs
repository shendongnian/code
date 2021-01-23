    MethodInfo method = null;
    foreach (var m in typeof(GenericExcuteTestClassExtension)
                      .GetMethods(BindingFlags.Public | BindingFlags.Static))
    {
        var parameters = m.GetParameters();
        if (!parameters.Any())
            continue;
        var lastParameterType = parameters.Last().ParameterType;
        var genericArgument = lastParameterType
            .GetGenericArguments()
            .SingleOrDefault();
        // you can/should add more checks, using the Name for example
        if (genericArgument != null && genericArgument.IsGenericType)
        {
            method = m;
            break;
        }
    }
