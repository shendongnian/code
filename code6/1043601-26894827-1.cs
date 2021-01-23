    MailMessage mailMessage = new MailMessage();
    mailMessage.To.Add("Address1@test.com");
    mailMessage.From = new MailAddress("Address2@test.com");
    mailMessage.Subject = "Subject";
    mailMessage.Body = "Body";
    using (MemoryStream memoryStream = new MemoryStream())
    {
         byte[] contentAsBytes = Encoding.UTF8.GetBytes("Test");
         memoryStream.Write(contentAsBytes, 0, contentAsBytes.Length);
         memoryStream.Seek(0, SeekOrigin.Begin);
         ContentType contentType = new ContentType();
         contentType.MediaType = MediaTypeNames.Text.Plain;
         contentType.Name = "Test.txt";
          Attachment attach = new Attachment(memoryStream, contentType);
          mailMessage.Attachments.Add(attach);
          SmtpClient smtp = new SmtpClient();
          try
          {
              smtp.Send(mailMessage);
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException);
          }
    }
