    public class TestController : Controller
        {
            public ActionResult Index()
            {
                return View(new MyViewModel());
            }
    
            [HttpPost]
            public ActionResult GetScore(MyViewModel userInputDetails)
            {
                if (ModelState.IsValid)
                {
                    userInputDetails.Name = "Meeee";
                    userInputDetails.Gender = "Yes Please!";
                    ModelState.Clear();
                }
                return PartialView("_MyPartialView", userInputDetails);
            }
        }
