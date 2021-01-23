    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            MyViewModel model = new MyViewModel(); 
            model.Foo = GetFooFromDbSynchronously();
            model.Bar = GetBarFromDbSynchronously();
            model.Baz = GetBazFromDbSynchronously();
            return View(model);
        }
    }
