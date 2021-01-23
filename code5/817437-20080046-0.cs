            var mailMessage = new MailMessage("test@example.com", email_txt.Text, "Hello", "Test");
            mailMessage.IsBodyHtml = true;
            byte[] attachmentData; //get attachment data as byte array.
            var attachmentStream = new MemoryStream(attachmentData);
            var attachment = new Attachment(attachmentStream, "Test");
            mailMessage.Attachments.Add(attachment);
            var smtpClient = new SmtpClient(smtpServer);
            smtpClient.Send(mailMessage);
