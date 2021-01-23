    public ActionResult Index()
        {
            DataAccess da = new DataAccess();
            //Getting all generated Menus and SubMenus
            var AllMenus = da.ConvertToGeneratedMenus(da.generateUserMenus("UserID")).ToList();
            //Getting MainMenus (where ParentID==0 in my case)
            var mainMenus = AllMenus.Where(mm => mm.ParentID == 0).ToList();
            //Getting SubMenus (where ParentID != 0 in my case)
            var subMenus = AllMenus.Where(sm => sm.ParentID != 0).ToList();
            //Assigning my MainMenus and SubMenus to two ViewBag properties(MainMenusList,SubMenuList) respectively 
            ViewBag.MainMenusList = mainMenus;
            ViewBag.SubMenuList = subMenus;
                                             
            return View();
        }
