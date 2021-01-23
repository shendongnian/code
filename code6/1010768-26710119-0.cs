    private static MemoryStream GetStatement(OracleConnection con, int loginId)
    {
     var memoryStream = new MemoryStream();
     using (
     var oraQuery = new OracleCommand(@"SELECT statement_file from user_account_statement where login_id=:1, con))
     {
      oraQuery.BindByName = true;
      oraQuery.Parameters.Add(":1", OracleDbType.Int32).Value = loginId;
      using (var oraQueryResult = oraQuery.ExecuteReader())
      if (oraQueryResult != null)
      {
       while (oraQueryResult.Read())
       {
        var blob = new Byte[(oraQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
        oraQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
        memoryStream.Write(blob, 0, blob.Length);
       }
      }
     }
     return memoryStream;
    }
