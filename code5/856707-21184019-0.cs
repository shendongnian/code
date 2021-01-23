    public class MyController : Controller
    {
        HttpContextBase _context;        
        public MyController(HttpContextBase context)
        {
            _context = context
        }
        public void UploadFile(string siteId, string sitePageId)
        {
            int fileCount = _context.Request.Files.Count;
    
            //Rest of code
        }
    }
