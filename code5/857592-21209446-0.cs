    var smtp = new SmtpClient
    {
        Host = "smtp.gmail.com",
        Port = 587,
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
    };
    var message = new MailMessage(fromAddress, toAddress)
    {
        Subject = subject,
        Body = body,
    };
    smtp.SendCompleted += (s, e) => {
        SendCompletedCallback(s, e);
        smtp.Dispose();
        message.Dispose();
    };
    string userState = "Test";
    message.Attachments.Add(new Attachment(Dir));
    smtp.SendAsync(message, userState);
