    public class refresh : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            FormlessPage page = new FormlessPage();
            Control ctrl = page.LoadControl("~/RepeaterHoster.ascx");
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            page.Controls.Add(ctrl);
            page.RenderControl(hw);
            context.Server.Execute(page, hw, false);
            context.Response.Write(sw.ToString());
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
