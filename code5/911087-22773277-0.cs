    // look for the "input" parameter and try to instantiate it and see if it implements the interface I'm interested in
    var parameterDescriptor = actionContext.ActionDescriptor.GetParameters().FirstOrDefault(p => string.Compare(p.ParameterName, inputKey, StringComparison.InvariantCultureIgnoreCase) == 0);
    if (parameterDescriptor == null 
        || (inputArgument = Activator.CreateInstance(parameterDescriptor.ParameterType) as IHasBlahBlahId) == null)
    {
        // if missing "input" parameter descriptor or it isn't an IHasBlahBlahId, then return unauthorized
        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        return;
    }
    
    // otherwise, take that newly instantiated object and throw it into the ActionArguments!
    if (actionContext.ActionArguments.ContainsKey(inputKey))
        actionContext.ActionArguments[inputKey] = inputArgument;
    else
        actionContext.ActionArguments.Add(inputKey, inputArgument);
