    private void SendMail()
    {
    MailMessage mail = new MailMessage();
    SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
    mail.From = new MailAddress(MailConst.From);
    mail.To.Add(new MailAddress("recepient@gmail.com"));
    mail.Subject = "Test";
    mail.Body = "This is a test";
    mailClient.EnableSsl = true;
    mailClient.Credentials = new NetworkCredential("Username", "Password");
    try
    {
        mailClient.Send(mail);
    }
    catch(Exception ex)
    {
        WriteErrorOutput(ex.Message);
    }
    }
