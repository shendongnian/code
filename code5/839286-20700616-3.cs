    private static Dictionary<Type, SqlDbType> types;
    public static SqlDbType GetSqlDbType(Type type, string propertyName)
    {
        if (types == null)
        {
            types = new Dictionary<Type, SqlDbType>();
            types.Add(typeof(Int32), SqlDbType.Int);
            types.Add(typeof(Int32?), SqlDbType.Int);
            types.Add(typeof(decimal), SqlDbType.Decimal);
            // etc
        }
        SqlDbType result;
        if (types.TryGetValue(type, out result))
        {
            return result;
        }
        else
        {
            return SqlDbType.VarBinary;
        }
    }
