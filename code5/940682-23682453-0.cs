    [Microsoft.SqlServer.Server.SqlFunction(DataAccess = DataAccessKind.Read)]
    public static bool Function1(string arg1)
    {
        using (SqlConnection sqlCnn = new SqlConnection("context connection=true"))
        {
            return Function1(arg1, sqlCnn);
        }
        return true;
    }
    
    [Microsoft.SqlServer.Server.SqlFunction(DataAccess = DataAccessKind.Read)]
    public static bool Function1(string arg1, SqlConnection sqlCnn)
    {
        //... Some code here using sqlCnn which we won't close or dispose.
        // as it's up to the caller to do that
        return true;
    }
    
    [Microsoft.SqlServer.Server.SqlFunction(DataAccess = DataAccessKind.Read)]
    public static bool Function2(string arg1)
    {
        using (SqlConnection sqlCnn = new SqlConnection("context connection=true"))
        {
            bool ret1 = Function1(arg1, sqlCnn);
            //... Some code here.
        }
        return true;
    }
