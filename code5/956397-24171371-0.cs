    static void Main(string[] args)
    {
        var mimeMessage = MimeMessage.Load(@"x:\sample.eml");
        var attachments = mimeMessage.Attachments.ToList();
        if (attachments.Any())
        {
            // Only multipart mails can have attachments
            var multipart = mimeMessage.Body as Multipart;
            if (multipart != null)
            {
                foreach(var attachment in attachments)
                {
                    multipart.Remove(attachment);
                }
            }
            mimeMessage.Body = multipart;
        }
        mimeMessage.WriteTo(new FileStream(@"x:\stripped.eml", FileMode.CreateNew));
    }
