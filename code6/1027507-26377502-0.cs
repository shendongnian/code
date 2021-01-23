    public class MyController : Controller
    {
        private Lazy<IRepository> _repository = new Lazy<IRepository>(
            () => new MyDataContextRepository(Membership.GetUser().ProviderUserKey));
    
        private IRepository Repository
        {
            get { return _repository.Value; }
        }
    
        [HttpPost]
        [Authorize]
        public ActionResult GetMyData()
        {
            var result = Repository.GetData(); // the repository constructor will get called here
            return Json(result);
        }
    }
