    MailMessage msg = new MailMessage();
    AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
    Stream stream = new MemoryStream(attachment.Bytes);// Bytes of file
    LinkedResource resource = new LinkedResource(stream);                                                               
    resource.ContentId = attachment.Name.Replace(".", "") + DateTime.Now.Ticks.ToString();
    resource.ContentType.Name = attachment.Name;//Name of file              
    resource.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;                               
    alternate.LinkedResources.Add(resource);
    msg.AlternateViews.Add(alternate);
