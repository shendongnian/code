    public class SimpleTestCase : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/xml";
            context.Response.Write("<?xml version=\"1.0\"?>" + Environment.NewLine);
            context.Response.Write("<root>");
            for (var i = 0; i < 400010; i++)
            {
                context.Response.Write("<amount>5</amount>" + Environment.NewLine);
            }
            context.Response.Write("</root>");
            context.Response.Flush();
            context.Response.End();
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
