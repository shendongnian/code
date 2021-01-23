    protected void RegisterUser_CreatingUser(object sender, LoginCancelEventArgs e)
    {
        TextBox EmailTextBox = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Email") as TextBox;
        String emailParam = EmailTextBox.Text;
    
        using (SqlConnection con = new SqlConnection(strCon))
        {
            con.Open();
            using (SqlCommand cmd = con.CreateCommand())
            {
               cmd.CommandText = "SELECT Email FROM Memberships WHERE Email=@emailParam";
               cmd.Parameters.AddWithValue("@emailParam", emailParam);
    
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                  if (reader.Read())
                  {
                      LabelExists.Text = "This e-mail is already registered";
                      e.Cancel = true; //Cancels registration
                  }
                else
                {
                    //create the user
                }
    
             }
          }
         con.Close();
       }
    }
