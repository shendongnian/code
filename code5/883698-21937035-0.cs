       public ActionResult Index()
        {
          var items = themes.Select(o => new SelectListItem {Text = o, Value = o, Selected = o == theme});
          return View(items);
        }
