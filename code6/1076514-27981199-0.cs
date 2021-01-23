    using (OracleConnection connectiontodb = new OracleConnection(databaseconnectionstring))
        {
            connectiontodb.Open();
            using (OracleBulkCopy copytothetable = new OracleBulkCopy(connectiontodb))
            {
        OracleTransaction tran = connectiontodb.BeginTransaction(IsolationLevel.ReadCommitted);
              try
              {
                copytothetable.ColumnMappings.Add("TBL_COL1", "TBL_COL1"); 
                copytothetable.ColumnMappings.Add("TBL_COL2", "TBL_COL2"); 
                copytothetable.ColumnMappings.Add("TBL_COL3", "TBL_COL3"); 
                copytothetable.DestinationTableName = "DESTINATION_TABLE";
                copytothetable.WriteToServer(datatable);
                tran.Commit();
              }
              catch
              {
                tran.Roolback();
              }
            }
        }
