    static string GetDataValue()
    {
      using ( SqlConnection conn = new SqlConnection("your-connect-string-here"))
      using ( SqlCommand    cmd  = conn.CreateCommand() )
      {
        InitializeSqlCommand(cmd) ;
        conn.Open() ;
        using ( SqlDataReader reader = cmd.ExecuteReader() )
        {
          while ( reader.Read() && reader.IsDBNull( 0 ) )
          {
            string value = reader[0].ToString() ;
            return value ;
          }
        }
      }
      throw new InvalidOperationException("no [useful] data returned");
    }
