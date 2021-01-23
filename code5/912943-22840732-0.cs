    public SqlType[] SqlTypes
    {
        get
        {
            SqlType[] types = new SqlType[1];
            types[0] = new SqlType(DbType.Int32);
            return types;
        }
    }
