          protected void email_TextChanged(object sender, EventArgs e)
        {
          
            string email= email.Text;
               
                string conStr;
                conStr = ConfigurationManager.ConnectionStrings["cnSting_Con"].ConnectionString;
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                // WRITE STORED PROCEDURE TO CHECK EMAIl ID 
                SqlCommand cmd = new SqlCommand("CheckEmailExist  ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", email));
               
                DataTable ds = new DataTable();
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                sd.Fill(ds);
                con.Close(); 
    
