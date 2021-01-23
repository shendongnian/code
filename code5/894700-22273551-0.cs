    DataTable mappings = new DataTable();
    OleDbCommand cmd = MyOleDbConnection.CreateCommand();
    
    cmd.CommandText 
      = "select * from " + mappingsTable
      + " where regexp_like(?, SmHeatLikePattern, 'i')"
      + " and UPPER(destinTablename) = UPPER(?)";
    OleDbParameter param1 = cmd.Parameters.Add(sourceTablename, OleDbType.VarChar);
    param1.Value = sourceTablename;
    
    OleDbParameter param2 = cmd.Parameters.Add(destinTableName, OleDbType.VarChar);
    param2.Value = destinTableName;
    
    new OleDbDataAdapter(cmd).Fill(mappings);
