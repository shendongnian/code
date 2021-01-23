    MailMessage msg = new MailMessage();
    byte[] byteArray = Encoding.UTF8.GetBytes(str.ToString());
    Stream contentStream = new MemoryStream(byteArray);
    Attachment attachment = new Attachment(contentStream, "calendar.ics", "text/calendar");
    attachment.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
    msg.Attachments.Add(attachment);
