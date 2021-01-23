    public string CheckAssess(string emailAddress, string columnName)
    {
        string chkAssess;
    
        string MgrAssessQry = "SELECT '"+columnName+"' FROM tblAllUsers";
        MgrAssessQry += " WHERE email ='" + emailAddress + "'";
    
        SqlCommand cmdReadAssess = new SqlCommand(MgrAssessQry, cn);
        cn.Open();
        SqlDataReader readAssess = cmdReadAssess.ExecuteReader();
    
        while(readAssess.Read())
        {
            // Add the rows
           chkAssess = readAssess["IsAssessMgr"].ToString();
        }
    
        return chkAssess;
    }
