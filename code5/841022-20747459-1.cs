    namespace FileUploadHandler
    {
        public class IISHandler1 : IHttpHandler
        {
            public bool IsReusable { get { return false; } }
            void IHttpHandler.ProcessRequest(HttpContext ctx)
            {
                HttpFileCollection uploadFile = ctx.Request.Files;
                string uploadFileResponse = "no count";
                if (uploadFile.Count > 0)
                {
                    uploadFileResponse = "count > 0";
                }
                
                ctx.Response.ContentType = "application/json; charset=utf-8";
                ctx.Response.Write(uploadFileResponse);
            }
        }
    }
