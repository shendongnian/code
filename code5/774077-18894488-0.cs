    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        var dataTransferManager = DataTransferManager.GetForCurrentView();
        dataTransferManager.DataRequested += DataRequested; 
    }
    
    public void DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
    {
        var Images = new List<string> 
        {
            "http://jenswinter.com/image.axd?picture=stackoverflow-logo-250.png",
            "http://en.flossmanuals.net/thunderbird/getting-support/_booki/thunderbird/static/Thunderbird-Support-tbird_support_superuser-en.jpg",
            "http://www.thomas-steinbrenner.net/wp-content/uploads/2010/11/Stackexchange_logo.png"
        };
    
        var res = GetHtml(Images);
        DataRequest request = args.Request;
    
        // The title is required. Otherwise it won't be shared.
        request.Data.Properties.Title = "Multi Image via Share Charm Using HTML.";
        DataRequestDeferral deferral = request.GetDeferral();
        try
        {
            string htmlFormat = HtmlFormatHelper.CreateHtmlFormat(res);
            request.Data.SetHtmlFormat(htmlFormat);
        }
        catch { }
        finally { deferral.Complete(); }
    }
    private string GetHtml(List<string> ImageUrls)
    {
        string ImgTag = @"<img src='{0}' /><br />";
        string Html = @"<html>
                    <head>
                    <title>Multi Image via Share Charm</title>
                    </head>
                    <body>
                    {0}
                    </body>
                    </html>";
        string AllImgTags = "";
        foreach (var url in ImageUrls)
        {
            AllImgTags += string.Format(ImgTag, url);
        }
    
        return string.Format(Html, AllImgTags);
    }
