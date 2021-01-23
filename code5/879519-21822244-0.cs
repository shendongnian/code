    public class ExamController : Controller
    {
        public ActionResult ChartReport(string parameter1, string parameter2)
        {
             ...
             // Return the contents of the Stream to the client
             return File(imgStream, "image/png");
        }
    }
