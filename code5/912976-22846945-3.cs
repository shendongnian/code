    OracleCommand getNextNodesC = new OracleCommand(QUERY_DEFINED_ABOVE.Replace("\r\n", "\n"), conn);
    getNextNodesC.BindByName = true;
    OracleParameter batchSizeP = new OracleParameter("BatchSize", OracleDbType.Int32);
    batchSizeP.Value = batchSize;
    getNextNodesC.Parameters.Add(batchSizeP);
    OracleParameter batchNameP = new OracleParameter("BatchName", OracleDbType.Varchar2);
    batchNameP.Value = batchName;
    getNextNodesC.Parameters.Add(batchNameP);
    OracleParameter returnCursor = new OracleParameter("rcursor", OracleDbType.RefCursor);
    returnCursor.Direction = ParameterDirection.ReturnValue;
    getNextNodesC.Parameters.Add(returnCursor);
            
    return getNextNodesC.ExecuteReader();
