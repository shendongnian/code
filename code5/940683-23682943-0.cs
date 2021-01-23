	[Microsoft.SqlServer.Server.SqlFunction(DataAccess = DataAccessKind.Read)]
	public static bool Function1(string arg1)
	{
	    using (SqlConnection sqlCnn = new SqlConnection("context connection=true"))
	    {
	        InnerFunction1(sqlCnn,arg1);
	    }
	    return true;
	}
	[Microsoft.SqlServer.Server.SqlFunction(DataAccess = DataAccessKind.Read)]
	public static bool Function2(string arg1)
	{
	    using (SqlConnection sqlCnn = new SqlConnection("context connection=true"))
	    {
	        InnerFunction2(sqlCnn,"arg1");
	    }
	    return true;
	}
	private static bool InnerFunction1(SqlConnection sqlCnn,string arg1)
	{
	        //... Some code here.	
	}
	private static bool InnerFunction2(SqlConnection sqlCnn,string arg1)
	{
	        bool ret1 = InnerFunction1(sqlCnn,"arg1");
	        //... Some code here.	        
	}
