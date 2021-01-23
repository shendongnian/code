    [Flags]
    public enum ValidationStatus
    {
      Valid         = 0 ,
      UserNameInUse = 1 ,
      EmailInUse    = 2 ,
    }
    public ValidationStatus ValidateUser( string userName , string emailAddr )
    {
      ValidationStatus status ;
      string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString ;
      
      using ( SqlConnection con = new SqlConnection( connectionString ) )
      using ( SqlCommand    cmd = con.CreateCommand() )
      {
        cmd.CommandText + @"
          select status = coalesce( ( select 1 from dbo.myTable t where t.UserName  = @UserName  ) , 0 )
                        + coalesce( ( select 2 from dbo.myTable t where t.UserEmail = @UserEmail ) , 0 )
           " ;
                cmd.Parameters.AddWithValue( "@UserName"  , userName  ) ;
                cmd.Parameters.AddWithValue( "@emailAddr" , emailAddr ) ;
         
        int value = (int) cmd.ExecuteScalar() ;
        status = (ValidationStatus) value ;
        
      }
      
      return status ;
    }
