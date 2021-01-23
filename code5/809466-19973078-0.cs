    class WebViewHandler
    {
        private static WebViewHandler instance;
        public bool isWebViewReady { get { return webView != null; } }
        public WPCordovaClassLib.CordovaView webView;
        private WebViewHandler()
        {
        }
        public void setWebView(ref WPCordovaClassLib.CordovaView webView)
        {
            this.webView = webView;
        }
        public static WebViewHandler getInstance()
        {
            if(instance == null){
                instance = new WebViewHandler();
            }
            return instance;
        } 
    }
