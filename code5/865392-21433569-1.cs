    public class BaseController : Controller
    {
        [OutputCache(Duration = 3600)] //cache 3600 sec
        public List<SomeDataModel> GetAllData()
        {
            return _dataGetter.GetAllData(User.Identity.Name);
        }
    }
