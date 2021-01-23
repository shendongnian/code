    public class YourController : Controller
    {
        public ActionResult Index()
        {
            var model = new RegisterViewModel();
            model.Degrees = new List<SelectListItem>
            {
                new SelectListItem { Text = "One", Value = "1"},
                new SelectListItem { Text = "Two", Value = "2"},
                new SelectListItem { Text = "Three", Value = "3"},
            };
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(RegisterViewModel model)
        {
            string degreeId = model.SelectedDegreeId;
                
        }
    }
