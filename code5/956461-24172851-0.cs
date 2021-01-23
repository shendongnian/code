    static Enum Or(Enum a, Enum b)
    {
        // consider adding argument validation here
        if (Enum.GetUnderlyingType(a.GetType()) != typeof(ulong))
            return (Enum)Enum.ToObject(a.GetType(), Convert.ToInt64(a) | Convert.ToInt64(b));
        else
            return (Enum)Enum.ToObject(a.GetType(), Convert.ToUInt64(a) | Convert.ToUInt64(b));
    }
