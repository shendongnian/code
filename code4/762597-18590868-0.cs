    public static string sendMail(string[] tolist, string title, string subject, string body)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    if (to == "")
                        to = "----@gmail.com";
                    MailAddressCollection m = new MailAddressCollection();
                     
                    //Add this
                    foreach(string to in tolist)
                    {
                        m.Add(to);
                    }
                    //
                    mail.Subject = subject;
                    mail.From = new MailAddress( "----@gmail");
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    mail.ReplyTo = new MailAddress("----@gmail");
                    
                    //And Add this 
                    foreach(MailAddress ma in m)
                    {
                        mail.To.Add(ma);
                    }
                    //or maybe just mail.To=m; 
                    
                    smtp.Host = "smtp.gmail.com";
                     client.Port = 25;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("----@gmail", "####");
                    ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; }; 
    
                    smtp.Send(mail);
    
                    return "done";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
