    public class ImageUrlProxy : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string url = context.Request.Headers["Url"];
                var client = new WebClient();
                byte[] imageDataBytes = client.DownloadData(url);
                context.Response.ContentType = "application/json;";
                context.Response.Write(JsonConvert.SerializeObject(imageDataBytes));
            }
            catch (Exception)
            {
                
                throw;
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
