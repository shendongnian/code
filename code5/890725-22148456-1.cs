    using System;
    using System.Web;
    using Newtonsoft.Json;
    public class Handler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string user= context.Request.Form["user"];
            //.....  
            var wrapper = new { d = myName };
            // in order to use JsonConvert you have to download the
            // Newtonsoft.Json dll from here  http://json.codeplex.com/
            context.Response.Write(JsonConvert.SerializeObject(wrapper));
        }
        public bool IsReusable
        {
           get
           {
                return false;
           }
        }
    }
