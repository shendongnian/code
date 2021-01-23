    Attachment attach;
    var attachStream = new MemoryStream(pdfBytes);
    try
    {
        attachStream = new Attachment(ms, "application/pdf");
        mailMessage.Attachments.Add(attachStream);
        // do other stuff to message
        // ...
        // and then send it.
        smtpClient.Send(MailMessage)
    }
    finally
    {
        attachStream.Close();
    }
