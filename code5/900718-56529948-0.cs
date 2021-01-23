         using (DbCommand objCmd = dbObject.GetSqlStringCommand(queryString))
            {
            ...
            objCmd.Parameters.Add("Ref_CursorName1",OracleDbType.RefCursor,ParameterDirection.Output);
            objCmd.Parameters.Add("Ref_CursorName2",OracleDbType.RefCursor,ParameterDirection.Output);
             ...
            connectoinObj.Open();
            objCmd.ExecuteNonQuery();
