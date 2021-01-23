    public class DocumentsHandler : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                Document doc; // any type
    
                if (doc!= null)
                {
                    context.Response.ContentType = MimeMapping.GetMimeMapping(doc.FileName);
                    context.Response.AddHeader("Content-Disposition", string.Format("filename={0}", doc.FileName));
                    context.Response.OutputStream.Write(doc.Data, 0, doc.Data.Length);
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
