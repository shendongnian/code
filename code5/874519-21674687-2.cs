    public class GetImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var fileName = context.Request.Params["fileName"];
            if (String.IsNullOrEmpty(fileName)) return;
            if (fileName.Contains("..")) return;
            //TODO: Add validation and any security check.
            context.Response.WriteFile("D:\\Images\\" + fileName);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
