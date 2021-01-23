    public abstract class MyWebViewPage<T> : WebViewPage<T>
    {
        protected LoginModel GetLoginModel()
        {
            // you could resolve some dependency here if you need to
            return /* add data here */
        }
    }
