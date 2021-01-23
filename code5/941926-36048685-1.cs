    public int AuthenticatedUserAge(String User_name)
    {
        string sql = "SELECT UserName, Age FROM tblDataProg WHERE (UserName ='" +   User_name  + "')";
        ds = GetDataSet(sql);
        int help = 0;
        int.TryParse(ds.Tables[0].Rows[0]["Age"].ToString(), out help);
        return help;    
    }
