    public class DownloadFile : IHttpHandler 
    {
    public void ProcessRequest(HttpContext context)
    {   
        // retrieve your xbook
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        xbook.Save(ms, C1.C1Excel.FileFormat.Biff8);
        xbook.Dispose();
        ms.Position = 0;
        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.ClearContent();
        response.Clear();
        response.ContentType = "application/vnd.ms-excel";
        response.AddHeader("Content-Disposition","attachment;filename=CategoryReport.xls");
        Response.BufferOutput = true;        
        Response.OutputStream.Write(ms.ToArray(), 0, (int)ms.Length);
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
