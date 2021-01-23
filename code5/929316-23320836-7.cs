    internal static int insertData(string spName, List<SqlParameter> sp = null)
    {
        ....
        if(sp != null)
            cmd.Parameters.AddRange(sp.ToArray());
        ....
    }
