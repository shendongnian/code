    string str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\inetpub\wwwroot\myfolder\mydatabase";
    string password = ""; 
    string accountemail="";
            using (OleDbConnection con = new OleDbConnection(str))
            {
                using (OleDbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT password, email FROM [users] WHERE username = ?";
                    cmd.Parameters.Add("user", OleDbType.VarChar).Value = Request.Form["UserName"];
                    con.Open();
    
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            password = reader["password"].ToString();
                            accountemail = reader["email"].ToString();
    
                        }
                    }
                }
            }
                        string fromaddress = "office email"; //send from admin/mail server
                        string toaddress = accountemail;  //send to respective user
                        string subject = "forgot password";
                        string body = String.Concat("This is the password that you have requested: " ,password, ". Please do not reply, this is an automated email."); //content of the email
                        try
                        {
                            var fromAddress = new MailAddress(from);
                            MailMessage mail = new MailMessage();
                            SmtpClient smtp = new SmtpClient();
    
                            MailAddressCollection m = new MailAddressCollection();
                            m.Add(toaddress);
                            mail.Subject = subject;
                            mail.From = new MailAddress(fromaddress);
                            mail.Body = body;
                            mail.IsBodyHtml = true;
                            mail.ReplyToList.Add(fromAddress);
                            mail.To.Add(m[0]);
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;
                            smtp.EnableSsl = true;
                            smtp.Credentials = new System.Net.NetworkCredential(from, "mypassword"); 
                            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
    
                            smtp.Send(mail);
    
                            MessageBox.Show("Success, your password has been sent to you.");
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                            Response.Redirect("Login.aspx", false);
                        }
