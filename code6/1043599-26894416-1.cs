    using (FileStream fs = new FileStream("Test.txt", FileMode.Create, FileAccess.ReadWrite))
    {
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine("Text");
        sw.Close();
    }
    MailMessage mailMessage = new MailMessage();
    mailMessage.To.Add("Address1@test.com");
    mailMessage.From = new MailAddress("Address2@test.com");
    mailMessage.Subject = "Subject";
    mailMessage.Body = "Body";
     Attachment attach = new Attachment("Test.txt", "Text/Plain"); //add a complete file path if needed
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
