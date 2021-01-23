    public abstract class Html2DocxController : Controller // please find a better name.
    {
        protected FileContentResult Html2DocxResult(string html, string fileDownloadName) 
        {
            byte[] docBytes = DocumentExport.Html2Docx(html);
    
            FileContentResult result;
            using (var ms = new MemoryStream(docBytes)) 
            {
                result = this.File(ms.ToArray(), "application/msword", fileDownloadName + ".docx");
            }
            return result;
        }
    }
