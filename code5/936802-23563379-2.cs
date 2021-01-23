        //
        // GET: /Menu/
        public ActionResult Index()
        {
            // Return the top level menu item
            var rootMenu = context.MenuItem.SingleOrDefault(x => x.ParentMenuItemId == null);
            return View(rootMenu);
        }
