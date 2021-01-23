    //Using:
    using Microsoft.ApplicationBlocks.Data;
    
    //Setting connection
    private static string _connection = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    
    //sending info to a stored proc (Which is better) in my opinion:
    SqlHelper.ExecuteNonQuery(_connection, "usp_AddUpdateTargets", week1target, week2target, week3target, week4target, UserID, TerritoryID);
