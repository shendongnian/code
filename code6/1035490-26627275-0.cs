    public class MyUrlHelper : UrlHelper
    {
        public override string Content(string contentPath)
        {
            // do your own custom implemetation here,
            // you access original Content() method using base.Content()
        }
    }
    public abstract class MyWebPage : WebViewPage
    {
        public new MyUrlHelper Url { get; private set; }
    }
    // provide generic version for strongly typed views
    public abstract class MyWebPage<T> : WebViewPage<T>
    {
        public new MyUrlHelper Url { get; private set; }
    }
