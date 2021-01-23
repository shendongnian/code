    public class afbeelding : IHttpHandler
    {
    
        public void ProcessRequest(HttpContext context)
        {
            int artikelnummer = 0;
    
            if (context.Request.QueryString["artikelnummer"] != null)
            {
                artikelnummer = int.Parse(context.Request.QueryString["artikelnummer"]);
            }
            if (artikelnummer != 0)
            {
                byte[] bytes = CBlob.getpicture(artikelnummer);
    
                if (bytes != null)
                {
                    context.Response.ContentType = "image/jpeg";
                    context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                }
            }
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
