    public DataTable myDataTable(string SQL, string ConnStr)
    {
        OracleConnection cn = default(OracleConnection);
        DataSet dsTemp = null;
        OracleDataAdapter dsCmd = default(OracleDataAdapter);
    
        cn = new OracleConnection(ConnStr);
        cn.Open();
    
        dsCmd = new OracleDataAdapter(SQL, cn);
        dsTemp = new DataSet();
        dsCmd.Fill(dsTemp, "myQuery");
        cn.Close();
        return dsTemp.Tables[0];
    }
