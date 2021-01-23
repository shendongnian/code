    I had the same problem. I resolved by a simple way like this.
    SqlDataReader read = null;
    and to check 'read' has row or not
    if(read.HasRows)
    {
       while(read.Read()){}
    }
   
    So please see this your code.
    public string CheckAssess(string emailAddress, string columnName)
    {
        string chkAssess;
        SqlDataReader readAssess;
        readAssess = null; // this from my comments
        string MgrAssessQry = "SELECT '"+columnName+"' FROM tblAllUsers";
        MgrAssessQry += " WHERE email ='" + emailAddress + "'";
        SqlCommand cmdReadAssess = new SqlCommand(MgrAssessQry, cn);
        cn.Open();
        readAssess = cmdReadAssess.ExecuteReader();
        if(readAssess.HasRows) // this from my comments
        {
           while(readAssess.Read())
           {
              // Add the rows
              chkAssess = readAssess["IsAssessMgr"].ToString();
           }
         }
         return chkAssess;
     }
 
     // I hope this code would help you.
   
