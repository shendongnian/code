    public class DownloadScheduleController : ApiController
    {
        public object Post(HtmlModel data)
        {
            var htmlContent = data.html;
    
            var pdfBytes = (new NReco.PdfGenerator.HtmlToPdfConverter()).GeneratePdf(htmlContent);
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30) };
            var cacheId = Guid.NewGuid().ToString();
            MemoryCache.Default.Add(cacheId, pdfBytes, policy);
            return new { id = cacheId };
        }
    
        public void Get(string id)
        {
            var pdfBytes = MemoryCache.Default.Get(id);
    
            using (var mstream = new System.IO.MemoryStream())
            {
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=UserSchedule.pdf");
                HttpContext.Current.Response.BinaryWrite(pdfBytes);
                HttpContext.Current.Response.End();
            }
        }
    }
