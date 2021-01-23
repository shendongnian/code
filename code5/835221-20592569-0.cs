    public class CityDetailsModel
    {
        public User User { get; set; }
        public IEnumerable<Cities> { get; set; }
    }
    public class UserController : Controller
    {
        //
        // GET: /Index/
        public ActionResult CityDetails()
        {
            CityDetailsModel model = new CityDetailsModel();
            model.User = new User();
            model.Cities = GetCityDetails();
            return View(model);
        }
    }
