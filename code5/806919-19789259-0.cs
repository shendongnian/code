    public class FileController : BaseController
    {
        private IService _childService;
        public IService ChildService { set { _childService = value; } }
        public JsonResult GetAll() { /*lot of code*/}
        public FileResult Download(int id) { /*lot of code*/}
        public JsonResult Post() { /*lot of code*/}
        public JsonResult Delete(IService childService) { /*lot of code*/}
    }
