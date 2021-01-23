    public class CarsController : Controller
    {
        public ActionResult Add(int carId)
        {
            // TODO : Validate the carId
            // TODO : Do the DB stuff to insert the car as you would in winforms
            return View("AddComplete"); // or whatever view
        }
    }
