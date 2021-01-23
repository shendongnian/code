    public static int FunctionCall(String value, String myConnectionString) {
      using (var conn = new OracleConnection(myConnectionString)) {
        conn.Open();
    
        using (var command = conn.CreateCommand()) {
          command.CommandText =
            @"begin
                :prm_Result := Fnc_Sistem(:prm_Argument);
              end;";
    
          command.Parameters.Add(":prm_Result", OracleDbType.Varchar2, ParameterDirection.Output);
          command.Parameters.Add(":prm_Argument", OracleDbType.Varchar2).Value = value;
    
          command.ExecuteNonQuery();
    
          return int.Parse(command.Parameters[0].Value.ToString());
        }
      } 
    }
    ....
    
    int myValue = FunctionCall("myValue", myConnectionString);
