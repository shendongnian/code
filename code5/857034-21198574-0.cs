    static void InsertIntoDb( string key , string value )
    {
      string connectString = "your-connect-string-here" ;
      Func<string,string> qt = s => s.Replace("'" , "''") ;
      using( SqlConnection sql = new SqlConnection(connectString) )
      using ( SqlCommand    cmd = sql.CreateCommand() )
      {
        cmd.CommandText = string.Format( @"insert dbo.RainbowTable( md5 , text ) values ( '{0}' , '{1}' )" , qt(key) , qt(value) ) ;
        cmd.CommandType = CommandType.Text;
        sql.Open();
        cmd.ExecuteNonQuery() ;
        sql.Close() ;
      }
      return ;
    }
