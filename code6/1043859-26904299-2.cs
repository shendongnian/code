    private void SendActivationEmail(string userId)
    {
     string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
     string activationCode = Guid.NewGuid().ToString();
     try
     {
       using (SqlConnection sqlConnection = new SqlConnection(connectionString))
       {
         SqlCommand sqlCommand = new SqlCommand("spInsertActivationCode", sqlConnection);
         sqlCommand.CommandType = CommandType.StoredProcedure;
         sqlCommand.Parameters.AddWithValue("@UserId", userId);
         sqlCommand.Parameters.AddWithValue("@ActivationCode", activationCode);
         sqlConnection.Open();
         sqlCommand.ExecuteNonQuery();
         sqlConnection.Close();
         //Afer successfull inserion of Activation Code You can send mail 
         using (MailMessage message = new MailMessage("sender@gmail.com", txtEmail.Text))
         {
           message.Subject = "Account Activation";
           string body = "Hello " + txtUsername.Text.Trim() + ",";
           body += "<br /><br />Please click the following link to activate your account";
           body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("User.aspx", "User_Activation.aspx?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";
           body += "<br /><br />Thanks";
           message.Body = body;
           message.IsBodyHtml = true;
           SmtpClient smtpClient = new SmtpClient();
           smtpClient.Host = "smtp.gmail.com";
           smtpClient.EnableSsl = true;
           NetworkCredential networkCredentials = new NetworkCredential("sender@gmail.com", "<password>");
           smtpClient.UseDefaultCredentials = false;
           smtpClient.Credentials = networkCredentials;
           smtpClient.Port = 587;
           smtpClient.Send(message);
         }
       }
     }
     catch (Exception ex)
     {
       //error
     }
    }
