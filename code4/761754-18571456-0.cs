    static MethodInfo GetPrivateMethod(Type type, string name)
    {
        MethodInfo retVal;
        do
        {
            retVal = type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            if (retVal != (object)null)
                break;
            type = type.BaseType;
        } while (type != (object)null);
        return retVal;
    }
