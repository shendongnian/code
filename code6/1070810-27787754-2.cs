    public class HomeController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Post(YourViewModel Submitted)
        {
            //Handle submitted data here
            foreach(var QuestionID in Submitted.QuestionIDs)
            {
                //Do something
            }
        }
    }
