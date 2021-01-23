    string oraConnectionString = "Data source=nkpdb;User id=hr;password=password;";
    OracleConnection oraConnection = new OracleConnection(oraConnectionString);
    oraConnection.Open();
    /* Would be better to put this in a stored procedure */      
    string sqlQuery = "select ic.column_name "  +
                      "     , ie.column_expression " +
                      "  from all_ind_columns ic " +
                      "  left join all_ind_expressions ie " +
                      "    on ie.index_owner      = ic.index_owner " +
                      "   and ie.index_name      = ic.index_name " +
                      "   and ie.column_position = ic.column_position " +
                      " where ic.index_owner   = :INDOwner " +
                      "   and ic.index_name    = :INDName" ;
    OracleCommand oraCmd     = new OracleCommand(sqlQuery, oraConnection);
    OracleParameter indOwner = new OracleParameter("INDOwner", 
                                                    OracleDbType.Varchar2);
    OracleParameter indName  = new OracleParameter("INDName", 
                                                    OracleDbType.Varchar2);
    indOwner.Value = "HR";
    indName.Value = "FBI";
    oraCmd.Parameters.Add(indOwner);
    oraCmd.Parameters.Add(indName);
    /* set up initial amount of data that the OracleDataReader 
     * fetches for LONG column */
    oraCmd.InitialLONGFetchSize = 1000;  /* set initial size */ 
    OracleDataReader oraDataReader = oraCmd.ExecuteReader();
    if (oraDataReader.HasRows)
    {
         while (oraDataReader.Read())
         {
           Console.WriteLine(oraDataReader.GetString(
                                   oraDataReader.GetOrdinal("column_expression")));
          }
     }
