    this.webControl1.ShowCreatedWebView += this.webControl1_ShowCreatedWebView;
    
    private void webControl1_ShowCreatedWebView(object sender, Awesomium.Core.ShowCreatedWebViewEventArgs e)
    {
        webControl2.Source = e.TargetURL;
    }
