    var parameters = method.GetParameters();
    object[] args = new object[parameters.Length];
    for (int i = 0; i < args.Length; i++)
    {
        if (i < providedArgs.Length)
        {
            args[i] = providedArgs[i];
        }
        else if (parameters[i].HasDefaultValue)
        {
            args[i] = parameters[i].DefaultValue;
        }
        else
        {
            throw new ArgumentException("Not enough arguments provided");
        }
    }
    method.Invoke(method.IsStatic ? null : this, args);
