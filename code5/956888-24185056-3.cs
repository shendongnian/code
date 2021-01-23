    public class FileHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //For multiple files
            foreach (string f in context.Request.Files.AllKeys)
            {
                HttpPostedFile file = context.Request.Files[f];
                if (!String.IsNullOrEmpty(file.FileName)) {
                    string test = file.FileName;
                }  
            }
        }
    }
    
    
  
