        public abstract class CustomWebViewPage<T> : WebViewPage<T>
        {
            public UrlHelper Url { get; set; }
        
            public override void InitHelpers()
            {
                if (true){Url = new CustomUrlHelper(ViewContext.RequestContext);}
                else{Url = new UrlHelper(ViewContext.RequestContext);}
        
            }
        }
