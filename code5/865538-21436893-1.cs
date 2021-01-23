            MailMessage mail = new MailMessage("\"Company Name\" <info@company.com>", textBox_Email_to.Text);
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "host name";
            mail.Subject = "test email";
            mail.Body = file; // file contains some text
            
            //mail.Headers.Add("reply-to", "service@company.de");
            mail.ReplyToList.Add(new MailAddress("service@company.de", "reply-to"));
            
            mail.IsBodyHtml = true;
            client.Send(mail);
