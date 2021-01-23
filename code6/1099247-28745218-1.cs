    public class FilesController : Controller
    {
         //I guess you would want to lookup by filename?
         public FileResult Index(string filename ){
                var fileToReturn = new FileStream("full path to file", FileMode.Open);
                return File(fileToReturn, "content-disposition", "fileName.extension");
         }
    }
