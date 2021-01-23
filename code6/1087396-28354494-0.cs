    private void AddScriptFunctions<T>(Assembly assembly, Dictionary<string, T> funMap) where T : class
    {
        foreach (Type type in assembly.GetTypes())
        {
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                if (IsMethodCompatibleWithDelegate<T>(method)))
                {
                    var function = (T) (object) Delegate.CreateDelegate(typeof (T), method);
                    funMap.Add(method.Name.ToLower(), function);
                }
            }
        }
    }
    public bool IsMethodCompatibleWithDelegate<T>(MethodInfo method) where T : class
    {
        Type delegateType = typeof(T);
        MethodInfo delegateSignature = delegateType.GetMethod("Invoke");
        bool parametersEqual = delegateSignature
            .GetParameters()
            .Select(x => x.ParameterType)
            .SequenceEqual(method.GetParameters()
                .Select(x => x.ParameterType));
        return delegateSignature.ReturnType == method.ReturnType &&
               parametersEqual;
    }
