    internal static ConstructorInfo GetConstructorForType(Type type)
    {
        System.Diagnostics.Debug.Assert(type != null);
        ConstructorInfo ci = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.CreateInstance, null, System.Type.EmptyTypes, null);
            if (null == ci)
            {
                ThrowConstructorNoParameterless(type);
            }
        return ci;
    }
