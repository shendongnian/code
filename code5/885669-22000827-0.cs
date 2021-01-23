    void Application_BeginRequest(object sender, EventArgs e)
    {
        // Bug fix for MS SSRS Blank.gif 500 server error missing parameter IterationId
        // https://connect.microsoft.com/VisualStudio/feedback/details/556989/
        if (HttpContext.Current.Request.Url.PathAndQuery.StartsWith("/Reserved.ReportViewerWebControl.axd") &&
         !String.IsNullOrEmpty(HttpContext.Current.Request.QueryString["ResourceStreamID"]) &&
            HttpContext.Current.Request.QueryString["ResourceStreamID"].ToLower().Equals("blank.gif"))
        {
            Context.RewritePath(String.Concat(HttpContext.Current.Request.Url.PathAndQuery, "&IterationId=0"));
        }
    }
