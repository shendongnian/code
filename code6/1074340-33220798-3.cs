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
        public static List<SelectListItem> GetGenderValues()
        {
            return new List<SelectListItem> 
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
