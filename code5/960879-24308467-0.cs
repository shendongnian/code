    OracleTransaction trans = conn.BeginTransaction(IsolationLevel.RepeatableRead);
    OracleCommand cmd = new OracleCommand(insertSql, conn, trans);
    cmd.Parameters.Add(new OracleParameter("BOX_ID", OracleDbType.Number));
    cmd.Parameters[0].Value = listOfBoxIds;   // int[] listOfBoxIds;
    cmd.ExecuteArray();
    OracleCommand cmd2 = new OracleCommand(storedProc, conn, trans);
    cmd2.CommandType = CommandType.StoredProcedure;
    cmd2.ExecuteNonQuery();
    trans.Commit();
