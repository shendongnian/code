    System.Net.Mail.Attachment attachment = null;
        using (var ms = new System.IO.MemoryStream())
        {
            using (var sw = new System.IO.StreamWriter(ms))
            {
                sw.Write("contents here");
                sw.Flush();
            }
            ms.Position = 0;
            attachment = new System.Net.Mail.Attachment(ms, "FileNameHere.txt");
        }
        var msg = new System.Net.Mail.MailMessage()
        {
            Body = "body text here",
            Subject = "some subject"
        };
        msg.Attachments.Add(attachment);
