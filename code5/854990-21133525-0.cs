    bool HasPublicGetter (PropertyInfo pi) 
    {
        if (!pi.CanRead)
            return false;
        MethodInfo getter = pi.GetMethod;
        return getter.IsPublic;
    }
