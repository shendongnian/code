    dynamic htmlView = AlternateView.CreateAlternateViewFromString(_Body.ToString(), null, "text/html");
    if (!string.IsNullOrEmpty(_EmailLogo1)) {
        LinkedResource logo = new LinkedResource(_EmailLogo);
        logo.ContentId = "logo2";
        htmlView.LinkedResources.Add(logo);
    }
    if (!string.IsNullOrEmpty(_EmailLogo))
    {
    LinkedResource logo1 = new LinkedResource(_EmailLogo1);
    logo1.ContentId = "logo1";
    htmlView.LinkedResources.Add(logo1);
    aMessage.AlternateViews.Add(htmlView);
    }
