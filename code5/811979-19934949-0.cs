    if (SaveDocument.HasFile)
    {
            /* Create the email attachment with the uploaded file */
        System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(SaveDocument.PostedFile.InputStream);
            /* Attach the newly created email attachment */
        message.Attachments.Add(attach);                  
    }
