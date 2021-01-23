    // Notice how we're deriving from BaseController
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = new StudentViewModel();
            model.Id = 1;
            model.Name = "John";
            model.Courses = BuildSelectList(this.courses,
                                            m => m.Id, m => m.Name);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            // The model wasn't valid, so repopulate the dropdown
            model.Courses = BuildSelectList(this.courses, m => m.Id,
                                            m => m.Name, model.CourseId);
            return View(model);
        }
    }
