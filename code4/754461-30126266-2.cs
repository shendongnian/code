    private void sendInlineImg() {
        MailMessage mail = new MailMessage();
        mail.IsBodyHtml = true;
        mail.AlternateViews.Add(getEmbeddedImage("c:/image.png"));
        mail.From = new MailAddress("yourAddress@yourDomain");
        mail.To.Add("recipient@hisDomain");
        mail.Subject = "yourSubject";
        //YourSMTPClient.Send(mail); //* Set up your SMTPClient before!
    }
    private AlternateView getEmbeddedImage(String filePath) {
        LinkedResource inline = new LinkedResource(filePath);
        inline.ContentId = Guid.NewGuid().ToString();
        string htmlBody = @"<img src='cid:" + inline.ContentId + @"'/>";
        AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
        alternateView.LinkedResources.Add(inline);
        return alternateView;
    }
