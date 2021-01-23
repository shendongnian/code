    using (var mCon = new OracleConnection(MyConnectionString))
    {
        myCon.Open();
    
        using (OracleCommand myOracleCmd = myCon.CreateCommand())
        {
            myOracleCmd.CommandType = CommandType.StoredProcedure;
            myOracleCmd.CommandText = "PRO_COMPANYSEARCH";
            myOracleCmd.Parameters.Add("o_result_cur", OracleDbType.RefCursor, ParameterDirection.Output);
            myOracleCmd.Parameters.Add("o_sqlcode", OracleDbType.Int32, ParameterDirection.Output);
            myOracleCmd.Parameters.Add("o_sqlmsg", OracleDbType.Varchar2, ParameterDirection.Output);
            myOracleCmd.Parameters["O_sqlmsg"].Size = 255;
            myOracleCmd.ExecuteNonQuery();
            var myReader = ((OracleRefCursor)myOracleCmd.Parameters["o_result_cur"].Value).GetDataReader();
            dtCompany.Load(myReader);
        }
    }
