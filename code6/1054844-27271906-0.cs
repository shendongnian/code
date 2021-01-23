    using (Stream myXlsFileStream = new MemoryStream())
    {
        CreateXlsToStream(myXlsFileStream);
        myXlsFileStream.Flush();
        MailMessage message = new MailMessage();
        // configure mail message contents ...
        using (Attachment xlsAttachment = new Attachment(
            myXlsFileStream, 
           "FileNameToAppearInEmail.xls", 
           "application/xls"))
        {
            message.Attachments.Add(xlsAttachment);
            // send the message
        }
    }
