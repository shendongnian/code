     public class FileDownload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
            {
                //Track your id
                string id = context.Request.QueryString["id"];
                //save into the database 
                string fileName = "YOUR-FILE.pdf";
                context.Response.Clear();
                context.Response.ContentType = "application/pdf";
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                context.Response.TransmitFile(filePath + fileName);
                context.Response.End();
               //download the file
            }
