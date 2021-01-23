    AlternateView av = AlternateView.CreateAlternateViewFromString(str,null,MediaTypeNames.Text.Html);
    LinkedResource lr = new LinkedResource("E:\\Photos\\hello.jpg",MediaTypeNames.Image.Jpeg);
    lr.ContentId = "image1";
    av.LinkedResources.Add(lr);
    message.AlternateViews.Add(av);
