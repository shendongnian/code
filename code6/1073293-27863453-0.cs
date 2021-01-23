    using (var connection = new OracleConnection(connstring))
    {
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            // Start a local transaction
            using (var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                // Assign transaction object for a pending local transaction
                command.Transaction = transaction;
                command.CommandText = "FNC_AXA_APPTS";
                command.CommandType = CommandType.StoredProcedure;
                OracleParameter retVal = new OracleParameter("PRS", OracleDbType.RefCursor);
                retVal.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(retVal);
                command.Parameters.Add(new OracleParameter("EG_PARAM", OracleDbType.Varchar2, 50)).Value = paramValue;
                command.ExecuteNonQuery();
                using (OracleDataReader reader = ((OracleRefCursor)command.Parameters["PRS"].Value).GetDataReader())
                {
                    dt.Load(reader);
                }
            }
        }
    }
