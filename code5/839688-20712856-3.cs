    string connect_string = "Server=localhost;Database=sandbox;Trusted_Connection=True;" ;
    
    string myXmlString    = @"
      <items>
        <item><id> 1 </id><name> alpha   </name></item>
        <item><id> 2 </id><name> bravo   </name></item>
        <item><id> 3 </id><name> charlie </name></item>
        <item><id> 4 </id><name> delta   </name></item>
      </items>
    " ;
    
    using ( SqlConnection conn = new SqlConnection(connect_string) )
    using ( SqlCommand    cmd  = conn.CreateCommand() )
    {
      cmd.CommandText = "dbo.insert_items" ;
      cmd.CommandType = CommandType.StoredProcedure ;
      cmd.Parameters.AddWithValue( "@item_list" , myXmlString ) ;
      conn.Open() ;
      cmd.ExecuteNonQuery() ;
      conn.Close() ;
    }
