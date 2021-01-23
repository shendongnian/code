     public static void sendEmail(string emailAdd,string userID){
      try
        {
            SqlConnection con = new SqlConnection(@"");
            con.Open();
            MailMessage mail = new MailMessage("example@gmail.com", emailAdd);
            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential nc = new NetworkCredential("example@gmail.com", "test");
            
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
           // smtpClient.Host = "smtp.google.com";
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            smtpClient.Credentials = nc;
            smtpClient.Send(mail);
            using (SqlCommand cmd = con.CreateCommand())
            {
                string sql = "UPDATE TestTable SET IsSent = 'true' WHERE  UserID = " + userID;
                SqlCommand myCommand = new SqlCommand(sql, con);
                int rows = myCommand.ExecuteNonQuery();
            }
        }
        catch(Exception e)
        {
            string message = e.Message;
        }`
     }
