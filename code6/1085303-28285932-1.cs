    using ( SqlConnection connection = new SqlConnection(connectString) )
    using(  SqlCommand cmd =  connection.CreateCommand() )
    {
      cmd.CommandText = "dbo.mySproc" ;
      cmd.CommandType = CommandType.StoredProcedure ;
      
      cmd.Parameters.AddWithValue( "@p1" , "Emily" ) ;
      
      cmd.Parameters.Add( "@p2" , SqlDbType.VarChar , 8000 );
      cmd.Parameters["@p2"].Direction = ParameterDirection.Output ;
      
      connection.Open();
      int rc = cmd.ExecuteNonQuery();
      connection.Close();
      
      string message = (string) cmd.Parameters["@p2"].Value ;
      Console.WriteLine( "The message is: {0}",message);
      
    }
