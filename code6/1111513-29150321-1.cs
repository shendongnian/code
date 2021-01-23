    void MyWebView_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
    {
        MyWebView.InvokeScriptAsync("getHeight", null);
    }
    
    void MyWebView_ScriptNotify(object sender, NotifyEventArgs e)
    {
        string result = e.Value.ToString();
        MyWebView.Height = double.Parse(result);
    }
