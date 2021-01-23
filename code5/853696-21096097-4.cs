    public static String GetProviderParameter(string paramName, IDbConnection con)
    {
        string prefix = "";
        if(con is System.Data.SqlClient.SqlConnection)
            prefix = "@";
        else if(con is System.Data.OleDb.OleDbConnection)
            prefix =  "?";
        else if(con is System.Data.Odbc.OdbcConnection)
            prefix =  "?";
        else if(con is MySql.Data.MySqlClient.MySqlConnection)
            prefix =  "?";
        return prefix + paramName;
    }
