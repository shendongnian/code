    switch (Type.GetTypeCode(typeof(T)))
    {
        case TypeCode.Int32:
            BitConverter.GetBytes((Int32)data);
            break;
        case TypeCode.Int64:
            BitConverter.GetBytes((Int64)data);
            break;
            ...
    }
