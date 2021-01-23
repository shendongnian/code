    MailMessage mail = new MailMessage();
    
    System.Text.Encoding theEncoding = System.Text.Encoding.ASCII;
    byte[] theByteArray = theEncoding.GetBytes(sw.ToString());
    MemoryStream theMemoryStream = new MemoryStream(theByteArray, false);
    mail.Attachments.Add(new Attachment(theMemoryStream, "YOUR_FILE_NAME.xls"));
    
    // Do remainder of your email settings here, To, From, Subject, etc.
