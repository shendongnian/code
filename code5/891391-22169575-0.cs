    public string CheckAssess(string emailAddress, string columnName)
    {
        string chkAssess;
        SqlDataReader readAssess;
        string MgrAssessQry = "SELECT '"+columnName+"' FROM tblAllUsers WHERE email ='" + emailAddress + "'";
        SqlCommand cmdReadAssess = new SqlCommand(MgrAssessQry, cn);
        
        cn.Open();
        readAssess = cmdReadAssess.ExecuteReader();
        while(readAssess.Read())
        {
            chkAssess = readAssess["IsAssessMgr"].ToString();
        }
        return chkAssess;
    }
