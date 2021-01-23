        MailMessage myMessage = new MailMessage();
        //subject line
        myMessage.Subject = Your Subject;
        //whats going to be in the body
        myMessage.Body = Your Body Info;
        //who the message is from
        myMessage.From = (new MailAddress("Mail@Mail.com"));
        //who the message is to
        myMessage.To.Add(new MailAddress("Mail@Mail.com"));
        //sends the message
        SmtpClient mySmtpClient = new SmtpClient();
        mySmtpClient.Send(myMessage);
