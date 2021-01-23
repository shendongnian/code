    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var items = new List<NodeViewModel>();
            var root = new NodeViewModel { Id = 1, Title = "Root" };
            items.Add(root);
            root.Children.Add(new NodeViewModel { Id = 2, Title = "One" });
            root.Children.Add(new NodeViewModel { Id = 3, Title = "Two" });
            this.ViewBag.Tree = items;
            return View();
        }
    }
    public class NodeViewModel
    {
        public NodeViewModel()
        {
            this.Expanded = true;
            this.Children = new List<NodeViewModel>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Expanded { get; set; }
        public bool HasChildren
        {
            get { return Children.Any(); }
        }
        public IList<NodeViewModel> Children { get; private set; }
    }
