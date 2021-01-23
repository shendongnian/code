    static bool ConditionExists( string someParameterValue )
    {
      bool exists ; // our return value
      
      const string query = @"
        select convert(bit,sign(count(*)))
        from foo t
        where t.someColumn = @p1
        " ;
      string connectionString = GetConnectionString() ;
      
      using ( SqlConnection connection = new SqlConnection(connectionString) )
      using ( SqlCommand    cmd        = connection.CreateCommand() )
      {
        cmd.CommandText = query ;
        cmd.CommandType = CommandType.Text;
        connection.Open() ;
        exists = (bool) cmd.ExecuteScalar() ;
        connection.Close() ;
      }
      
      return exists ;
    }
