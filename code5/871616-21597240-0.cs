    public class SubmitController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Download(string id)
        {
            string filename = String.Format("{0}.pdf", id);
            return File(System.IO.File.ReadAllBytes(Server.MapPath("~/Content/") + filename), "application/octet-stream", filename);
        }
	}
