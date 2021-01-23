    public static byte[] Serialize<T>(this T instance)
    {
        if (!Attribute.IsDefined(typeof(T), typeof(ProtoContractAttribute)))
        {
            throw new Exception(...);
        }
    }
