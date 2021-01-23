    public class EdmxController : Controller
    {
        //
        // GET: /Edmx/
        public ActionResult Index()
        {
            DDLModel model = new DDLModel();
            model.Items = new List<string>();
    
            using (var entities = new SampleEntities1())
            {
                model.Items = entities.GiveNames().ToList();
    
            }
            return View(model);
        }
    }
    
    public class DDLModel
    {
        public List<String> Items { get; set; }
    }
