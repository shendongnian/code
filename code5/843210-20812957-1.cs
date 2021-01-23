        public class MyImageHandler : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                context.Response.ContentType = "image/png";
                context.Response.WriteFile(@"C:\Users\User\Desktop\Section-13.png");
            }
            public bool IsReusable
            {
                get { return true; }
            }
        }
