    private static MethodInfo GetMethod(IEnumerable<MethodInfo> methods, Type typeA, Type typeB)
    {
        foreach (var method in methods)
        {
            MethodInfo candidate;
            if (!method.IsGenericMethod) { candidate = method; }
            else
            {
                try
                {
                    candidate = method.MakeGenericMethod(method.GetGenericArguments().Length == 1 ? new[] {typeA} : new[] {typeA, typeB});
                }
                catch (ArgumentException ex)
                {
                    if (ex.Message.Contains("violates the constraint of type")) continue;
                    throw;
                }
            }
    
            var args = candidate.GetParameters();
    
            if (args[0].ParameterType.IsAssignableFrom(typeA) && args[1].ParameterType.IsAssignableFrom(typeB)) return candidate;
        }
    
        return null;
    }
