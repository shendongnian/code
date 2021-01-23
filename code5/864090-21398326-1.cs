    public class MenuController : Controller
    {
        public ActionResult IndexNew()
        {
            MenuModel model = new MenuModel();
            model.li = LoadUl();
           
            return PartialView("_MenuForAdmin",model);
        }
    
        public List<string> LoadUl()
        {
            List<string> list = new List<string>();
            list.Add("Testing");
            list.Add("MCV");
            list.Add("Project");
            return list;
        }
    }
