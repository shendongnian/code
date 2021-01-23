    public DataTable Fetchorders( DateTime dt )
    {
      DataTable dt = new DataTable() ;
      
      using ( SqlConnection conn = new SqlConnection( "..." ) )
      using ( SqlCommand    cmd  = conn.CreateCommand()       )
      using ( SqlDataAdapter sda = new SqlDataAdapter(cmd)    ) 
      {
        string query = @"
          SELECT o.*
          FROM Orders o
          WHERE o.DateLogged >= @date
            and o.DateLogged <  dateadd(day,1,@date)
          " ;
        
        cmd.CommandText = query ;
        cmd.CommandType = CommandType.Text ;
        cmd.Parameters.Add(
           new SqlParameter( "@date" , dt.Date , SqlDbType.DateTime )
           ) ;
        
        conn.Open() ;
        sda.Fill(dt) ;
        conn.Close() ;
        
      }
      
      return dt ;
    }
