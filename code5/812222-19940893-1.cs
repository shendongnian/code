    public static byte[] Serialize<T>(this T instance)
    {
        if (instance.GetType()
                    .GetCustomAttributes(typeof(ProtoContract), false).Length == 0)
        {
            throw new Exception(...);
        }
    }
