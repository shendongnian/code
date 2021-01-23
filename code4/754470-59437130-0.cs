    MailMessage mailWithImg = getMailWithImg();
    MySMTPClient.Send(mailWithImg); //* Set up your SMTPClient before!
    
    private MailMessage getMailWithImg()
    {
        MailMessage mail = new MailMessage();
        mail.IsBodyHtml = true;
        mail.AlternateViews.Add(getEmbeddedImage("c:/image.png"));
        mail.From = new MailAddress("yourAddress@yourDomain");
        mail.To.Add("recipient@hisDomain");
        mail.Subject = "yourSubject";
        return mail;
    }
    private AlternateView getEmbeddedImage(String filePath)
     {
        // below line was corrected to include the mediatype so it displays in all 
        // mail clients. previous solution only displays in Gmail the inline images 
        LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);  
        res.ContentId = Guid.NewGuid().ToString();
        string htmlBody = @"<img src='cid:" + res.ContentId + @"'/>";
        AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,  
         null, MediaTypeNames.Text.Html);
        alternateView.LinkedResources.Add(res);
        return alternateView;
    }
