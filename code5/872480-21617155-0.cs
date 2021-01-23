    // Construct the MailMessage object to be relayed to the SMTP server
    message = new MailMessage("to@to.com", "from@test.com");
    string path = System.Web.HttpContext.Current.Server.MapPath(@"~/images/banner.jpg"); 
    byte[] image = LoadImageAsByteArray(path);
    // create a stream object from the file contents
    var stream = new MemoryStream(image);
    // create a mailAttachment object
    var mailAttachment = new System.Net.Mail.Attachment(stream, "bannerAttachment.jpg")
                         {
                           // set the content id of the attachment so our email src links are valid
                           ContentId = Guid.NewGuid().ToString("N")
                         };
    // set the attachment inline so it does not appear in the mail client as an attachment
    mailAttachment.ContentDisposition.Inline = true;
    // and then add the newly created mailAttachment object to the Attachments collection
    message.Attachments.Add(mailAttachment);
