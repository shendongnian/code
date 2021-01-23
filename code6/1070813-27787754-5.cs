    public class YourController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult PostExam(YourViewModel Submitted)
        {
            //Handle submitted data here
            foreach(var QuestionID in Submitted.QuestionIDs)
            {
                //Do something
            }
        }
    }
