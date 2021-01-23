    Public Class AdminBaseController : Controller {
        public ActionResult Index()
            {
                var model = _db.Menus.Include("MenuItems").First(m => m.Name == "Admin menu");
                ViewBag.AdminMenu = new MenuModelView
                {
                    Name = model.Name,
                    CssClass = model.CssClass,
                    CssId = model.CssId,
                    Deleted = model.Deleted,
                    MenuItems = model.MenuItems
                };
    
                return View();
            }
        }
