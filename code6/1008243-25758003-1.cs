    using (SqlConnection sqlConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString))
    {
        using (SqlCommand cmD = new SqlCommand("StoredProcName", sqlConn) { CommandType = CommandType.StoredProcedure })
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
