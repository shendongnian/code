    public class ListBoxController : Controller
    {
        public ActionResult Index()
        {
            ListBoxModel model = new ListBoxModel();
            model.Names = new List<string>();
            model.Names.Add("Rami");
            return View(model);
        }
        public ActionResult Submit(ListBoxModel model)
        {
            return null;
        }
	}
