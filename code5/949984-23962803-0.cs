    // Save the document to a byte buffer
    byte[] pdfBytes;
    using (var ms = new MemoryStream())
    {
        pdfDocument.Save(ms);
        pdfBytes = ms.ToArray();
    }
    // create the attachment
    Attachment attach;
    using (var ms = new MemoryStream(pdfBytes))
    {
        attach = new Attachment(ms, "application/pdf");
    }
    // and add it to the message
    mailMessage.Attachments.Add(attach);
