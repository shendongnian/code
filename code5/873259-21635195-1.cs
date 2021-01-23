    public static string GetName(Type enumType, object value)
    {
        [...]
        // this is actually in a method called by GetName, I put it here for clarity
        Type type = value.GetType();
        if (!type.IsEnum && !Type.IsIntegerType(type))
        {
            throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnumBaseTypeOrEnum"), "value");
        }
        [...]
    }
    // Type.IsIntegerType
    internal static bool IsIntegerType(Type t)
    {
        return t == typeof(int) || t == typeof(short) || t == typeof(ushort) || t == typeof(byte) || t == typeof(sbyte) || t == typeof(uint) || t == typeof(long) || t == typeof(ulong) || t == typeof(char) || t == typeof(bool);
    }
