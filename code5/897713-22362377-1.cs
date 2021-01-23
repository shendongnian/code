    using ( SqlConnection connection = new SqlConnection( "Server=localhost;Database=sandbox;Trusted_Connection=True;" ) )
    using ( SqlCommand    command    = connection.CreateCommand() )
    {
      
      command.CommandType = CommandType.StoredProcedure;
      command.CommandText = "dbo.AuthenticatePhone" ;
      
      SqlParameter phoneNumber = new SqlParameter {
        ParameterName = "@phoneNumber"           ,
        IsNullable    = true                     ,
        Direction     = ParameterDirection.Input ,
        Value         = 2125551212L              ,
        } ;
      command.Parameters.Add( phoneNumber ) ;
      
      SqlParameter userId = new SqlParameter {
        ParameterName = "@User_ID"                ,
        IsNullable    = true                      ,
        Direction     = ParameterDirection.Output ,
        DbType        = DbType.String             ,
        Size          = 1000                      ,
        Value         = DBNull.Value              ,
        } ;
      command.Parameters.Add( userId ) ;
      
      SqlParameter userName = new SqlParameter {
        ParameterName = "@User_Name" ,
        IsNullable    = true ,
        Direction     = ParameterDirection.Output ,
        DbType        = DbType.String ,
        Size          = 1000 ,
        Value         = DBNull.Value ,
        } ;
      command.Parameters.Add( userName ) ;
      
      connection.Open() ;
      int rowsAffected = command.ExecuteNonQuery() ;
      connection.Close() ;
      
      Console.WriteLine( "Rows Affected: {0}"     , rowsAffected             ) ;
      Console.WriteLine( "User ID:       {{{0}}}" , userId.Value   as string ) ;
      Console.WriteLine( "User Name:     {{{0}}}" , userName.Value as string ) ;
      
    }
