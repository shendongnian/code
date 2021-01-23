    public class Myandler : IHttpHandler
    {
      public void ProcessRequest(HttpContext context)
      {
         byte[] fileBytes;
         string fileName;
         
         //...get from byte[] from SQL Server
           context.Response.Clear();
           context.Response.ClearContent();
           context.Response.ClearHeaders();
           context.Response.Buffer = true;
           context.Response.ContentType = "application/octet-stream";
           context.Response.AddHeader("Content-Length", fileBytes.Length.ToString());
           context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
           context.Response.BinaryWrite(fileBytes);
           context.Response.Flush();
      }
     }
