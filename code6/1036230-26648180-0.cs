    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)] // will be applied to all actions in Controller, unless those actions override with their own decoration
        public class FilesController : Controller
        {
            public ActionResult GetFile(string id)
            {
                 return File();//do file 
            }
        }
