    private static bool IsTypeCompatibile(Type pattern, Type test, Type placeholder)
    {
        if (pattern == test || pattern == placeholder)
            return true;
        if(pattern.IsGenericType)
        {
            if (!test.IsGenericType || pattern.GetGenericTypeDefinition() != test.GetGenericTypeDefinition())
                return false;
            var patternGenericTypes = pattern.GetGenericArguments();
            var testGenericTypes = test.GetGenericArguments();
            return patternGenericTypes.Length == testGenericTypes.Length
                && patternGenericTypes.Zip(testGenericTypes, (p, t) => IsTypeCompatibile(p, t, placeholder)).All(x => x);
        }
        return false;
    }
