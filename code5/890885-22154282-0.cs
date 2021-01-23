    // Create an email message and identify the Exchange service.
    EmailMessage message = new EmailMessage(service);
    // Add properties to the email message.
    message.Subject = "Interesting";
    message.Body = "The merger is finalized.";
    message.ToRecipients.Add("user1@contoso.com");
    // Send the email message and save a copy.
    message.SendAndSaveCopy();
