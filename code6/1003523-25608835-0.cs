    private static bool CompareGenerics(MethodInfo m1, MethodInfo m2)
    {
        var args1 = m1.GetGenericArguments();
        var args2 = m2.GetGenericArguments();
        if (args1.Length != args2.Length)
            return false;
        for (int i = 0; i < args1.Length; i++)
        {
            if ((args1[i].GenericParameterAttributes ^ args2[i].GenericParameterAttributes) != 0)
                return false;
        }
        return true;
    }
