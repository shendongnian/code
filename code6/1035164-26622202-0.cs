        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string requestPath = Request.RawUrl.Trim().ToLower();
            HttpApplication app = sender as HttpApplication;
            if (!IsLocalRequest(app.Context.Request))
            {
                if (requestPath.IndexOf("form.aspx") > 0)
                {
                    throw new HttpException(404, "Error HTTP 404.0 – Not Found.");
                }
            }
        }
    // This method determines whether request came from the same IP address as the server.
    public static bool IsLocalRequest(HttpRequest request)
    {
        return request.ServerVariables["LOCAL_ADDR"] == request.ServerVariables["REMOTE_ADDR"];
    }
...
