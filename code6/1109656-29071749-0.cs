            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("yourMail", "yourPassword");
            smtp.EnableSsl = true;
 
            MailMessage msg = new MailMessage(sendFrom, "yourMail");
            
            msg.ReplyToList.Add(sendFrom);
            msg.Subject = subject;
            msg.Body = bodyTxt;
            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(@"C:\Projects\EverydayProject\test.txt");
            msg.Attachments.Add(attachment);
            smtp.Send(msg);
