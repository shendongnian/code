    public class MenuController : Controller
    {
    //
    // GET: /Menu/
    
    readonly  MenuClass _menu = new MenuClass();
    
    public ActionResult MenuPrivilages()
    {
        Session["username"] = "1001";
        if (Session.Count == 0)
        {
            return RedirectToAction("");
        }
        else
        {
            List<Menu> menuList = new List<Menu>();
            menuList = _menu.GetAllMenuItems();
            return View(menuList);    
        }            
    }
    }
