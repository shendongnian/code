    using ( OracleConnection conn = new OracleConnection(oradb))
    {
      conn.Open();
      OracleCommand cmd = new OracleCommand("LE_SELECET_EMPLOYEE_CUR", conn);
      cmd.CommandType = CommandType.StoredProcedure;
      var reader = cmd.ExecuteReader();
      //read all data here 
      conn.Close();//optional as you are using using
    }
