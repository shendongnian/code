    public class MyController
    {
        private readonly IFileRepository _fileRepository;
        //Wire up the IFileRepository injection via IoC container (Ninject, StructureMap, etc.)
        public MyController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        [HttpPost]
        public ActionResult SaveFile(HttpPostedFileBase file) //assuming you're just posting a file
        {
            //note: instead of HttpPostedFileBase you could iterate through
            //      Request.Files
            if(file == null)
            {
                //do something here b/c the file wasn't posted...
            }
            try
            {
                _fileRepository.Save(file);
            }
            catch(Exception ex)
            {
                //log exception...display friendly message to user, etc...
            }
            return View("MyView");
        }
    }
