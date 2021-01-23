    using (SqlConnection sqlConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString))
    {
        string stR = @"select COALESCE(@listStr + ';' ,'') + eml_ID AS listStr from EmailGroup where eml_Level=3 and eml_Stat=1";
        using (SqlCommand cmD = new SqlCommand(stR, sqlConn))
        {
            sqlConn.Open();
            SqlDataReader dR = cmD.ExecuteReader();
            cmD.Parameters.Add("@listStr", SqlDbType.VarChar).Value = "test";
            while (dR.Read())
            {
                string emailFullName = Session["UserFullName"].ToString(); 
                string email = Session["UserEmailAdd"].ToString();
                 //more code here
             }
         }
     }
