    public class Controller {
        public ActionResult Index(){
            var mainViewModel = new MainViewModel { PartialViewModel = new PartialViewModel() };
            return View(mainViewModel);
        }
    }
