    webView.SetWebViewClient (new MyWebViewClient());
    
    // ...
    
    public class MyWebViewClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.Settings.UserAgentString = "your-user-agent-here";
            view.LoadUrl(url);
            return true;
        }
    }
