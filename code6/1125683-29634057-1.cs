        public AwesomiumMenu(string Source, Microsoft.Xna.Framework.Rectangle rectangle)
        {
            // CSS styling
            const string SCROLLBAR_CSS = "::-webkit-scrollbar { visibility: hidden; }";
            WebCore.Initialize(new WebConfig()
            {
                CustomCSS = SCROLLBAR_CSS
            });
            webView = WebCore.CreateWebView(rectangle.Width, rectangle.Height);
            webView.ReduceMemoryUsage();
            webView.Source = Source.ToUri();
            webView.IsTransparent = true;
            while (webView.IsLoading)
                WebCore.Update();
            Rectangle = rectangle;
            JSObject menu = webView.CreateGlobalJavascriptObject("menu");
            menu.BindAsync("onButtonClick", myJSMethodHandler);
        }
