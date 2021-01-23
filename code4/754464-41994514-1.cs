    EmailMessage email = new EmailMessage(service);
    email.Subject = "Email with Image";
    email.Body = new MessageBody(BodyType.HTML, html);
    email.ToRecipients.Add("abc@xyz.com");
    string file = @"C:\Users\acv\Pictures\Logo.jpg";
    email.Attachments.AddFileAttachment("Logo.jpg", file);
    email.Attachments[0].IsInline = true;
    email.Attachments(0).ContentId = "Logo.jpg";
    email.SendAndSaveCopy();
