    public static Task<int> Execute(Assembly assembly, string[] args, IServiceProvider serviceProvider)
    {
        object instance;
        MethodInfo entryPoint;
        if (!TryGetEntryPoint(assembly, serviceProvider, out instance, out entryPoint))
        {
            return Task.FromResult(-1);
        }
        object result = null;
        var parameters = entryPoint.GetParameters();
        if (parameters.Length == 0)
        {
            result = entryPoint.Invoke(instance, null);
        }
        else if (parameters.Length == 1)
        {
            result = entryPoint.Invoke(instance, new object[] { args });
        }
        if (result is int)
        {
            return Task.FromResult((int)result);
        }
        if (result is Task<int>)
        {
            return (Task<int>)result;
        }
        if (result is Task)
        {
            return ((Task)result).ContinueWith(t =>
            {
                return 0;
            });
        }
        return Task.FromResult(0);
    }
