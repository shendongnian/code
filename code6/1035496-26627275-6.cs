    public class MyUrlHelper : UrlHelper
    {
        public MyUrlHelper() {}
        public MyUrlHelper(RequestContext requestContext) : base(requestContext) {}
        public MyUrlHelper(RequestContext requestContext, RouteCollection routeCollection) : base(requestContext, routeCollection) { }
        public override string Content(string contentPath)
        {
            // do your own custom implemetation here,
            // you access original Content() method using base.Content()
        }
    }
    public abstract class MyWebPage : WebViewPage
    {
        protected override void InitializePage()
        {
            this._urlHelper = new MyUrlHelper(this.Request.RequestContext, RouteTable.Routes);
        }
        private MyUrlHelper _urlHelper;
        public new MyUrlHelper Url { get { return _urlHelper; } }
    }
    // provide generic version for strongly typed views
    public abstract class MyWebPage<T> : WebViewPage<T>
    {
        protected override void InitializePage()
        {
            this._urlHelper = new MyUrlHelper(this.Request.RequestContext, RouteTable.Routes);
        }
        private MyUrlHelper _urlHelper;
        public new MyUrlHelper Url { get { return _urlHelper; } }
    }
