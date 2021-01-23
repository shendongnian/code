    public class Handler : IHttpHandler, IReadOnlySessionState
    {
       public bool IsReusable { get { return true; } }
       
       public void ProcessRequest(HttpContext ctx)
       {
            string file = ctx.Session[Request.QueryString["file"]];
            if (file!=null)
            {
               Response.Clear();
               Response.ContentType = "application/octet-stream";
               Response.AddHeader(string.Format("Content-Disposition", "attachment; filename={0}",Path.GetFileName(file)));                                            
               Response.WriteFile(Server.MapPath(file));
               Response.End();
             }
       }
    }
