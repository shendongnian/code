    SmtpClient smtpClient = new SmtpClient("gmial.com", 25);
        smtpClient.Credentials = new System.Net.NetworkCredential("youremailid@gmail.com", "yourPassword");
        smtpClient.UseDefaultCredentials = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;
        MailMessage mail = new MailMessage();
        //Setting From , To and CC
        mail.From = new MailAddress("fromemailid@gmail.com", "MyWeb Site");
        mail.To.Add(new MailAddress("toemailid@gmail.com"));
        mail.CC.Add(new MailAddress("ccemailid@gmail.com"));
        mail.Subject = "your subject";
        mail.IsBodyHtml = true;
        mail.Body = "<h1>your message body</h1>";
        smtpClient.Send(mail);
