    MailMessage mail = new MailMessage();
    try
    {
    mail.To.Add(destinatario); // where will send
    mail.From = new MailAddress("email that will send", "how the email will be displayed");
    mail.Subject = "";
    mail.SubjectEncoding = System.Text.Encoding.UTF8;
    mail.IsBodyHtml = true;
    
    mail.Priority = MailPriority.High;
    
    // mail body
    mail.Body = "email body";
    
     // send email, dont change //
    SmtpClient client = new SmtpClient();
    
    client.Credentials = new System.Net.NetworkCredential("gmail account", "gmail pass"); // set 1 email of gmail and password
    client.Port = 587; // gmail use this port
    client.Host = "smtp.gmail.com"; //define the server that will send email
    client.EnableSsl = true; //gmail work with Ssl
    
    client.Send(mail);
    mail.Dispose();
    return true;
    }
    catch
    {
    mail.Dispose();
    return false;
    }
