    static string GetDataValue()
    {
      string value ;
      using ( SqlConnection conn = new SqlConnection("your-connect-string-here"))
      using ( SqlCommand    cmd  = conn.CreateCommand() )
      {
        InitializeSqlCommand(cmd) ;
        conn.Open() ;
        value = (string) cmd.ExecuteScalar() ;
        conn.Close() ;
      }
      if ( value == null ) throw new InvalidOperationException("no data read") ;
      return value ;
    }
