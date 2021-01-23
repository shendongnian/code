    message.To.Add(recieve + "@txt.att.net");
    message.From = new MailAddress(user);
    message.Subject = subject;
    message.Body = body;
    if (!string.IsNullOrEmpty(add_photo.FileName))
    {
        message.Attachments.Add(new Attachment(add_photo.FileName));
    }    
    client.Send(message);
