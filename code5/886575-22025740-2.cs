    class Program
    {
      
      static byte[] Sha1Hash( string s )
      {
        SHA1    sha1         = SHA1.Create() ;
        Encoding windows1252 = Encoding.GetEncoding(1252) ;
        byte[]   octets      = windows1252.GetBytes(s) ;
        byte[]   hash        = sha1.ComputeHash( octets ) ;
        
        return hash ;
      }
      
      static string HashToString( byte[] bytes )
      {
        StringBuilder sb = new StringBuilder() ;
        
        for ( int i = 0 ; i < bytes.Length ; ++i )
        {
          byte b = bytes[i] ;
          if ( i > 0 && 0 == i % 4 ) sb.Append( ' ' ) ;
          sb.AppendFormat( b.ToString("X2") ) ;
        }
        
        string s = sb.ToString() ;
        return s ;
      }
      
      private static DataTable ReadDataFromSqlServer()
      {
        DataTable dt = new DataTable();
        
        using ( SqlConnection conn = new SqlConnection( "Server=localhost;Database=sandbox;Trusted_Connection=True;"))
        using ( SqlCommand cmd = conn.CreateCommand() )
        using ( SqlDataAdapter sda = new SqlDataAdapter(cmd) )
        {
          cmd.CommandText = "select * from dbo.hash_test" ;
          cmd.CommandType = CommandType.Text;
          conn.Open();
          sda.Fill( dt ) ;
          conn.Close() ;
        }
        
        return dt ;
      }
      
      static void Main()
      {
        DataTable dt = ReadDataFromSqlServer() ;
        
        foreach ( DataRow row in dt.Rows )
        {
          int    id            = (int)    row[ "id"          ] ;
          string sourceText    = (string) row[ "source_text" ] ;
          byte[] sqlServerHash = (byte[]) row[ "hash"        ] ;
          byte[] myHash        = Sha1Hash( sourceText ) ;
          
          Console.WriteLine();
          Console.WriteLine( "{0:##0}: {1}" , id , sourceText ) ;
          Console.WriteLine( "   sql: {0}" , HashToString( sqlServerHash ) ) ;
          Console.WriteLine( "   c#:  {0}" , HashToString( myHash        ) ) ;
          Debug.Assert( sqlServerHash.SequenceEqual(myHash) ) ;
          
        }
        
        return ;
      }
      
    }
