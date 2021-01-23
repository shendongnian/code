    private static MethodInfo GetMethod(IEnumerable<MethodInfo> methods, Type typeA, Type typeB)
    {
        foreach (var method in methods)
        {
            List<MethodInfo> candidates = new List<MethodInfo>();
            if (!method.IsGenericMethod) { candidates.Add(method); }
            else
            {
                MethodInfo genericMethod;
                if (IsParameterOfGeneric(typeA, typeB) && TryMakeGenericMethod(method, typeB, typeB, out genericMethod)) candidates.Add(genericMethod);
                if (IsParameterOfGeneric(typeB, typeA) && TryMakeGenericMethod(method, typeA, typeA, out genericMethod)) candidates.Add(genericMethod);
                if (typeA.IsGenericType && typeB.IsGenericType && TryMakeGenericMethod(method, typeA.GetGenericArguments()[0], typeB.GetGenericArguments()[0], out genericMethod)) candidates.Add(genericMethod);
                if (TryMakeGenericMethod(method, typeA, typeB, out genericMethod)) candidates.Add(genericMethod);
            }
    
            foreach (var candidate in candidates)
            {
                var args = candidate.GetParameters();
                if (args[0].ParameterType.IsAssignableFrom(typeA) && args[1].ParameterType.IsAssignableFrom(typeB)) return candidate;
            }
        }
    
        return null;
    }
    private static bool IsParameterOfGeneric(Type generic, Type parameter)
    {
        if (!generic.IsGenericType) return false;
        return generic.GetGenericArguments()[0] == parameter;
    }
    private static bool TryMakeGenericMethod(MethodInfo method, Type typeA, Type typeB, out MethodInfo genericMethod)
    {
        genericMethod = null;
        try
        {
            genericMethod = method.GetGenericArguments().Length == 1
                ? method.MakeGenericMethod(typeA)
                : method.MakeGenericMethod(typeA, typeB);
    
            return true;
        }
        catch (ArgumentException ex)
        {
            if (ex.Message.Contains("violates the constraint of type")) return false;
            throw;
        }
    }
