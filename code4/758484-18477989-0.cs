    public class DownloadFile : IHttpHandler 
    {
        public void ProcessRequest(HttpContext context)
        {   
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
            response.TransmitFile(Server.MapPath("FileDownload.csv"));
            response.Flush();    
            response.End();
        }
 
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
