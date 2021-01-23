    private static EqualityComparer<T> CreateComparer()
    {
        RuntimeType c = (RuntimeType) typeof(T);
        if (c == typeof(byte))
        {
            return (EqualityComparer<T>) new ByteEqualityComparer();
        }
        if (typeof(IEquatable<T>).IsAssignableFrom(c))
        {
            return (EqualityComparer<T>) RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType) typeof(GenericEqualityComparer<int>), c);
        } // RELEVANT PART
        if (c.IsGenericType && (c.GetGenericTypeDefinition() == typeof(Nullable<>)))
        {
            RuntimeType type2 = (RuntimeType) c.GetGenericArguments()[0];
            if (typeof(IEquatable<>).MakeGenericType(new Type[] { type2 }).IsAssignableFrom(type2))
            {
                return (EqualityComparer<T>) RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType) typeof(NullableEqualityComparer<int>), type2);
            }
        }
        if (c.IsEnum && (Enum.GetUnderlyingType(c) == typeof(int)))
        {
            return (EqualityComparer<T>) RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType) typeof(EnumEqualityComparer<int>), c);
        }
        return new ObjectEqualityComparer<T>(); // CURIOUS PART
    }
