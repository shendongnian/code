    using System.IO;
    using System.Web;
    
    namespace YourAppName
    {
        public class ServePDF : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                string fileToServe = context.Request.Path;
                //Log the user and the file served to the DB
                FileInfo pdf = new FileInfo(context.Server.MapPath(fileToServe));
                context.Response.ClearContent();
                context.Response.ContentType = "application/pdf";
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + pdf.Name);
                context.Response.AddHeader("Content-Length", pdf.Length.ToString());
                context.Response.TransmitFile(pdf.FullName);
                context.Response.Flush();
                context.Response.End();
            }
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
    }
