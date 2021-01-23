    // return back non generic interface to use in method
    private static INumberConverter ConverterFactory<T>() 
        where T : struct 
    {
        var typeCode = Type.GetTypeCode(typeof(T));
        switch (typeCode)
        {
            case TypeCode.SByte:
                return new GenericNumberConverter<sbyte>(SByte.Parse);
            case TypeCode.Byte:
                return new GenericNumberConverter<byte>(Byte.Parse);
            case TypeCode.Single:
                return new GenericNumberConverter<float>(Single.Parse);
            case TypeCode.Decimal:
                return new GenericNumberConverter<decimal>(Decimal.Parse);
            case TypeCode.Double:
                return new GenericNumberConverter<double>(Double.Parse);
            case TypeCode.Int16:
                return new GenericNumberConverter<short>(Int16.Parse);
            case TypeCode.Int32:
                return new GenericNumberConverter<int>(Int32.Parse);
            case TypeCode.Int64:
                return new GenericNumberConverter<long>(Int64.Parse);
            case TypeCode.UInt16:
                return new GenericNumberConverter<ushort>(UInt16.Parse);
            case TypeCode.UInt32:
                return new GenericNumberConverter<uint>(UInt32.Parse);
            case TypeCode.UInt64:
                return new GenericNumberConverter<ulong>(UInt64.Parse);
        }
        return null;
    }
