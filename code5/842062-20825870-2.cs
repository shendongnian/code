    using System.Net;
    using System.Net.Mail;
    
    string fromEmail = "FromYou@gmail.com";
    MailMessage mailMessage = new MailMessage(fromEmail, "ToAnyone@example.com", "Subject", "Body");
    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
    smtpClient.EnableSsl = true;
    smtpClient.UseDefaultCredentials = false;
    smtpClient.Credentials = new NetworkCredential(fromEmail, "password");
    try {
    	smtpClient.Send(mailMessage);
    }
    catch (Exception ex) {
    	//Error
    	//Console.WriteLine(ex.Message);
    	Response.Write(ex.Message);
    }
