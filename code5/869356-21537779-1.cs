    string connectString = "Server=localhost;Database=sandbox;Trusted_Connection=True;" ;
    using ( SqlConnection connection = new SqlConnection(connectString) )
    using ( SqlCommand    cmd        = connection.CreateCommand() )
    {
      
      cmd.CommandText = "select * from dbo.bin_test" ;
      cmd.CommandType = CommandType.Text ;
      
      connection.Open() ;
      using ( SqlDataReader reader = cmd.ExecuteReader() )
      {
        int row = 0 ;
        while ( reader.Read() )
        {
          for ( int col = 0 ; col < reader.FieldCount ; ++col )
          {
            Console.Write( "row{0,2}, col{1,2}: " , row , col ) ;
            SqlBinary octets = reader.GetSqlBinary(col) ;
            if ( octets.IsNull )
            {
              Console.WriteLine( "{null}");
            }
            else
            {
              Console.WriteLine( "length={0:##0}, {{ {1} }}" , octets.Length , string.Join( " , " , octets.Value.Select(x => string.Format("0x{0:X2}",x)))) ;
            }
          }
          Console.WriteLine() ;
          ++row ;
        }
      }
      connection.Close() ;
    }
