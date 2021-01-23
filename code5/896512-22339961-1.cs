      // Set the command
      OracleCommand cmd = new OracleCommand(
        "update multimedia_tab set story = :1 where thekey = 1");
      cmd.Connection = con;
      cmd.CommandType = CommandType.Text; 
      // Create an OracleClob object, specifying no caching and not a NCLOB
      OracleClob clob = new OracleClob(con, false, false);
      // Write data to the OracleClob object, clob, which is a temporary LOB
      string str = "this is a new story";
      clob.Write(str.ToCharArray(), 0, str.Length);
      // Bind a parameter with OracleDbType.Clob
      cmd.Parameters.Add("clobdata", 
                          OracleDbType.Clob, 
                          clob, 
                          ParameterDirection.Input);
      try 
      {
        // Execute command
        cmd.ExecuteNonQuery();
