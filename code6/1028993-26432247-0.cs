    private void SendMatchNotice(string body, string attachment, string email, bool pdf = false)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(ConfigurationManager.AppSettings["SMTP.SendFrom"]);
            message.Subject = ConfigurationManager.AppSettings["MatchedNoticeSubject"];
            message.To.Add(new MailAddress(email));
            message.ReplyToList.Add(new MailAddress(ConfigurationManager.AppSettings["SMTP.ReplyTo"]));
            message.Body = body;
            message.IsBodyHtml = true;
            // Create  the file attachment for this e-mail message.
            Attachment att = Attachment.CreateAttachmentFromString(attachment, "SeniorInfo.html", System.Text.Encoding.ASCII, System.Net.Mime.MediaTypeNames.Text.Html);
            System.Net.Mime.ContentDisposition disposition = att.ContentDisposition;
            disposition.DispositionType = "attachment";
            disposition.Inline = false;
            disposition.FileName = "SeniorInfo.html";
            disposition.CreationDate = DateTime.Now;
            disposition.ModificationDate = DateTime.Now;
            disposition.ReadDate = DateTime.Now;
            message.Attachments.Add(att);
            SmtpClient server = new SmtpClient()
            {
                EnableSsl = (ConfigurationManager.AppSettings["SMTP.EnableSSL"].ToLower() == "true"),
                Host = ConfigurationManager.AppSettings["SMTP.Server"],
                Port = Convert.ToInt16(ConfigurationManager.AppSettings["SMTP.Port"]),
                Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTP.Account"], ConfigurationManager.AppSettings["SMTP.Password"])
            };
            server.Send(message);
        }
