    private bool HandleShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navType)
    {
      if (navType == UIWebViewNavigationType.LinkClicked)
      {
        UIApplication.SharedApplication.OpenUrl(request.Url);
        return false;
      }
        return true;
    }
