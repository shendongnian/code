    //To create MailMessage object
                string strPassword = txtPassword.Text;
    	    string strEmailAddress = txtFromEmailAddress.Text;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");//Set SMTP to gmail
                mail.From = new MailAddress(strFromEmailAddress);//From side emailAdress
                mail.To.Add(txtClientAddress.Text);//To side email Address
                mail.Subject = strEmailTitle;//Subject to define
                mail.Body = PreviewEmail();//Appending the body string to the Mail Body
                mail.IsBodyHtml = true;
                System.Net.Mail.Attachment attachment;//Set attachment object
              
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
              
              
                SmtpServer.Credentials = new System.Net.NetworkCredential(strFromEmailAddress, strPassword);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
