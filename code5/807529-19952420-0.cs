    MailMessage mail = new MailMessage();
    mail.From = new System.Net.Mail.MailAddress("mygroup@somecompany.com");
    
    // The important part -- configuring the SMTP client
    SmtpClient smtp = new SmtpClient();
    smtp.Port = 587;   // [1] You can try with 465 also, I always used 587 and got success
    smtp.EnableSsl = true;
    smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
    smtp.UseDefaultCredentials = false; // [3] Changed this
    smtp.Credentials = new NetworkCredential(mail.From,  "password_here");  // [4] Added this. Note, first parameter is NOT string.
    smtp.Host = "smtp.somecompany.com";            
    
    //recipient address
    mail.To.Add(new MailAddress("yyyy@xxxx.com"));
    
    //Formatted mail body
    mail.IsBodyHtml = true;
   
    
    mail.Body = st;
    smtp.Send(mail);
