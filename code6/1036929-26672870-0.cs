    public static DataTable queryTable(string pStatement, OdbcConnection pConnection)
    {
       DataTable dt = new DataTable();
        OdbcDataAdapter da = new OdbcDataAdapter(pStatement, pConnection);
        var DS = new DataSet();
        da.Fill(DS);
        dt = DS.Tables[0];
    
        return dt;
    }
          
