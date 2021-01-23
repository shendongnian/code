     using (SqlConnection con = new SqlConnection (yourConnectionString))
        {
         SqlCommand mycmd = new SqlCommand("select UserId from Users where  username=@username and password=@password",con);
        //add parameters to pass the username & password here
          mycmd.Parameters.AddWithValue("@username", username.Text);
          mycmd.Parameters.AddWithValue("@password", password.Text);
         if (con.State != ConnectionState.Open)
          {
               con.Close();
               con.Open();
          }
         
         int userID = (int)mycmd.ExecuteScalar();
         Session["UserID"] = userID; //Store USerID in session
         con.Close();
        }
