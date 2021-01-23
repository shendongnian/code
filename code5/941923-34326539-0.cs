    public int AuthenticatedUserAge(String User_name)
    {
        string sql = "SELECT UserName, Age FROM tblDataProg WHERE (UserName ='" +   User_name  + "')";
        ds = GetDataSet(sql);
        //check for no results
        if(ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
           return 0;
        }
        //check for null
        if(ds.Tables[0].Rows[0]["Age"] == DBNull.Value)
        {
           return 0;
        }
        int help = int.Parse(ds.Tables[0].Rows[0]["Age"].ToString());
        return help;    
    }
