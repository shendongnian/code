    public class Myandler : IHttpHandler
    {
      public void ProcessRequest(HttpContext context)
      {
         byte[] fileBytes;
         string fileName;
         
         //...get from byte[] from SQL Server
           HttpContext.Current.Response.Clear();
           HttpContext.Current.Response.ClearContent();
           HttpContext.Current.Response.ClearHeaders();
           HttpContext.Current.Response.Buffer = true;
           HttpContext.Current.Response.ContentType = "application/octet-stream";
           HttpContext.Current.Response.AddHeader("Content-Length", fileBytes.Length.ToString());
           HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
           HttpContext.Current.Response.BinaryWrite(fileBytes);
           HttpContext.Current.Response.Flush();
      }
     }
