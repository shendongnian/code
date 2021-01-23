    public static T[] Plus<T>(T[] a, T[] b, int size)
    {
        switch(Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.Int32:
                return (T[])(object)Plus((int[])(object)a, (int[])(object)b, size);
            case TypeCode.Int64:
                return (T[])(object)Plus((long[])(object)a, (long[])(object)b, size);
            // ...etc
            default:
                throw new NotSupportedException();
        }
    }
