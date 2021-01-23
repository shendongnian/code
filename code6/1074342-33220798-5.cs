    public class MyController : Controller 
    {
        [HttpPost]
        public ActionResult MyAction(MyModel model)
        {
            // Do something
       
            return View();
        }
    }
    public class MyModel
    {
        public Gender Gender { get; set; }
        public static IEnumerable<SelectListItem> GetGenderValues()
        {
            return new [] 
            {
                new SelectListItem { Text = "Male", Value = "Male" };
                new SelectListItem { Text = "Female", Value = "Female" };
            };
        }
    }
   
    public enum Gender 
    {
        Male, Female
    }
