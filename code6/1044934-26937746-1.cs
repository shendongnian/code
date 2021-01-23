    public class YouHandlerPage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // REVIEW AND PROCESS THE REQUEST (i.e. ...
            //    context.Request.QueryString
            //    context.Request.RequestContext.RouteData.Values;
            //    context.Request.Form
            string fDirectory = @"C:\Users\john\Desktop\";
            string fileName = "ibc";
            string fileExt = "png";
            context.Response.StatusCode = 200;
            context.Response.ContentType = "Image/" + fileExt;
            //let context.Response.ContentLength be specified by the following WriteFile method
            context.Response.WriteFile(Format.String("{0}{1}.{2}", fDirectory, fileName, fileExt));
        }
        public bool IsReusable { get { return false;} }
    }
