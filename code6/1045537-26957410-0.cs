    public class HomeController : Controller
    {
        private readonly IReservation reservation;
        public HomeController(IReservation reservation)
        {
            this.reservation = reservation;
        }
        public ActionResult Index()
        {
            string me = this.reservation.getName();
            return View();
        }
    }
