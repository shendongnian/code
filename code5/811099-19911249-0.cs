    string body = "blah blah blah... body goes here with the image tag: <img src=\"cid:companyLogo\" width="104" height="27" />";
    byte[] reader = File.ReadAllBytes("E:\\TestImage.jpg");
    MemoryStream image1 = new MemoryStream(reader);
    AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);
                    
    LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
    headerImage.ContentId = "companyLogo";
    headerImage.ContentType = new ContentType("image/jpg");
    av.LinkedResources.Add(headerImage);
                
    
    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
    message.AlternateViews.Add(av);
    message.To.Add(emailTo);
    message.Subject = " Your order is being processed...";
    message.From = new System.Net.Mail.MailAddress("xxx@xxx.com");
    
    
    ContentType mimeType = new System.Net.Mime.ContentType("text/html");
    AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
    message.AlternateViews.Add(alternate);
