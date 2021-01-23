    public class UserController : Controller
    {
        public ActionResult Index()
        {
            User u = new User();
            return View(u);
        }
        public ActionResult FirstStep(User u)
        {
            u.Dates = new List<AvailabilityDates>();
            u.Dates.Add(new AvailabilityDates() { date = null });
            u.Dates.Add(new AvailabilityDates() { date = null });
            return View(u);
        }
        public ActionResult LastStep(User u)
        {
            // Do your stuff here
            return null;
        }
	}
