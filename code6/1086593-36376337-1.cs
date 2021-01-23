    var page = new WebControl
    {
        ViewType = WebViewType.Window,
    };  
    page.NativeViewInitialized += (s, e) =>
    {
        page.LoadHTML("<html>SOME TEXT</html>");
    };
