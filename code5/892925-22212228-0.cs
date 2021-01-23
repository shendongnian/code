    public class FilesController : Controller
    {
        public ActionResult List()
        {
            List<FileInfo> model = new List<FileInfo>();
            //  Grab all file names from the directory and place them within the model.
    
            return View(model);
        }
    
        public ActionResult View(string fileName)
        {
            //  Add header for content type
            //  Grab (and verify) file based on input parameter fileName
    
            return File(...);
        }
    
        public ActionResult Delete(string fileName)
        {
            //  Verify file exists
            //  Delete file if it exists
    
            return RedirectToAction("List");
        }
    }
