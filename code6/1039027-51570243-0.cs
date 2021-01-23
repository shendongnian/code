    public static SendEmail()
    {
               MailMessage mMailMessage = new MailMessage();
               //setup other email stuff
    
                if (File.Exists(attachmentPath))
                {
                    Attachment attachment = new Attachment(attachmentPath);
                    mMailMessage.Attachments.Add(attachment);
                    attachment.Dispose(); //disposing the Attachment object
                }
    } 
