    private void sendInlineImg() {
        MailMessage mail = new MailMessage();
        mail.IsBodyHtml = true;
        mail.AlternateViews.Add(getEmbeddeImage());
        mail.From = new MailAddress("yourAddress@yourDomain");
        mail.To.Add("recipient@hisDomain");
        mail.Subject = "yourSubject";
        //YourSMTPClient.Send(mail); //* Set your SMTPClient before!
    }
    private AlternateView getEmbeddeImage() {
        LinkedResource inline = new LinkedResource("c:/image.png"); //* Your file path
        inline.ContentId = Guid.NewGuid().ToString();
        string htmlBody = @"<img src='cid:" + inline.ContentId + @"'/>";
        AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
        alternateView.LinkedResources.Add(inline);
        return alternateView;
    }
