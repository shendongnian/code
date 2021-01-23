    var mailMessage = new MailMessage();
    mailMessage.From = new MailAddress("sender@domain.com", "Customer Service");
    mailMessage.To.Add(new MailAddress("someone@domain.com"));
    mailMessage.Subject = "A descriptive subject";
    mailMessage.IsBodyHtml = true;
    mailMessage.Body = "Body containing <strong>HTML</strong>";
