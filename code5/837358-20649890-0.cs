     SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(
                "insert  into dbo.UserInfo (Login, Password, UserType, ID) " +
                  " VALUES(@Login,@Password,@UserType) ", con);
                {
                    cmd.Parameters.AddWithValue("@Login",TextBox1.Text );
                    cmd.Parameters.AddWithValue("@Password", TextBox2.Text+".123");
                    cmd.Parameters.AddWithValue("@Type", DropDownList1.SelectedValue);
                  
                    int rows = cmd.ExecuteNonQuery();
    
                  con.Close(); 
                }
