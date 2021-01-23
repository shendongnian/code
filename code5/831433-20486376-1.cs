     SmtpClient smtpClient = new SmtpClient("mail.MyWebsiteDomainName.com", 25);
        
        smtpClient.Credentials = new System.Net.NetworkCredential("info@MyWebsiteDomainName.com", "myIDPassword");
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    MailMessage mail = new MailMessage();
        
        
                    //Setting From , To and CC
                    mail.From = new MailAddress("info@MyWebsiteDomainName", "MyWeb Site");
                    mail.To.Add(new MailAddress("info@MyWebsiteDomainName"));
                    mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));
        
        
        smtpClient.Send(mail);
