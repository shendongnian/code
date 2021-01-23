    using System;
    using System.Web;
    
    namespace WebApp.FileDownload
    {
        /// <summary>
        /// Summary description for download
        /// </summary>
        public class download : IHttpHandler
        {
    
            public void ProcessRequest(HttpContext context)
            {            
                context.Response.ContentType = "text/plain";
                context.Response.SetCookie(new HttpCookie("downloaded","true")); //setting cookie in the response
                string id = context.Request.QueryString["id"] == null ? "NULL" : context.Request.QueryString["id"];
                string str = string.Format("Content with id {0} was generated at {1}", id, DateTime.Now.ToLongTimeString());
                           
                context.Response.AddHeader("Content-Disposition", "attachment; filename=test.txt");
                context.Response.AddHeader("Content-Length", str.Length.ToString());
                context.Response.Write(str);
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
