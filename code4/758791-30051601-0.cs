    string htmlBody = String.Format("<html><body><img src=\"cid:{0}\" /></body></html>", "myContentId");
    AlternateView avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
    LinkedResource inline = new LinkedResource(imageStream, "image/png");
    inline.ContentId = "myContentId";
    inline.ContentType.MediaType = "image/png";
    avHtml.LinkedResources.Add(inline);
    emailMessage.AlternateViews.Add(avHtml);
    
    _emailSender.Send(emailMessage);
