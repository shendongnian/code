    if(File.Exists("screenshot.png"))
    {
       System.Net.Mail.Attachment attachment;
       attachment = new System.Net.Mail.Attachment("screenshot.png");
       msg.Attachments.Add(attachment);
    }
