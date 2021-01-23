    public class ErrorManagementModule : IHttpModule
    {
        public void Dispose() { }
        public void Init(HttpApplication context)
        {
            //handle context exceptions
            context.Error += (sender, e) => HandleError();
            //handle page exceptions
            context.PostMapRequestHandler += (sender, e) => 
                {
                    Page page = HttpContext.Current.Handler as Page;
                    if (page != null)
                        page.Error += (_sender, _e) => HandleError();
                };
        }
        private void HandleError()
        {
            Exception ex = HttpContext.Current.Server.GetLastError();
            if (ex == null) return;
            LogException(ex);
            HttpException httpEx = exception as HttpException;
            if (httpEx != null && httpEx.GetHttpCode() == 500)
            {
                HttpContext.Current.Response.Redirect("/PrettyErrorPage.aspx", true);
            }
        }
    }
