    public string CheckAssess(string emailAddress, string columnName)
    {
    string chkAssess = "";
    SqlDataReader readAssess;
    //readAssess = new SqlDataReader();
    string MgrAssessQry = "SELECT @Column_Name FROM tblAllUsers";
    
    SqlCommand cmdReadAssess = new SqlCommand(MgrAssessQry, cn);
    cmdReadAssess.Parameters.AddWithValue(new SqlParameter("Column_Name", columnName)); 
    cn.Open();
    readAssess = cmdReadAssess.ExecuteReader();
    while(readAssess.Read())
    {
        // Add the rows
        chkAssess = readAssess.GetString(0);
    }
    return chkAssess;
    }
