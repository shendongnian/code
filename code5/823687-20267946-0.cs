    public static Tuple<SqlConnection, SqlConnection> GetTwoConnections()
    {
        ...
        SqlConnection con1 = new SqlConnection(str1);
        SqlConnection con2 = new SqlConnection(str2);
        con1.Open();
        con2.Open();
        return Tuple.Create(con1, con2);
    }
