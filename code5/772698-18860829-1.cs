    using (MailMessage mail = new MailMessage())
    {
        mail.From = new MailAddress("From@mail.com");
        mail.To.Add("Me@mail.com");
    
        //format our file paths
        string filesDirectory = @"\server\folder\";
        string fileFullPath = Path.Combine(filesDirectory, fileName);
    
        //file doesnt exist so exit the method
        if (!File.Exists(fileFullPath))
            return;
    
        using (var pdfFile = new Attachment(fileFullPath))
        {
            mail.Subject = "PDF Files " + fileName;
            mail.Body = "Attached is the pdf file " + fileName + ".";
            mail.Attachments.Add(pdfFile);
    
            SmtpClient client = new SmtpClient("SMTP.MAIL.COM");
    
            client.Send(mail);
            //To release files and enable accessing them after they are sent.
        }
    }
