            public ActionResult Index()
        {
            var todo = new TodoMini() {URL = Request.Url.LocalPath};
            return View(todo);
        }
