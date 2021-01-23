      public ActionResult Create()
      {
           Admin admin = new Admin();
           admin.HireDate = DateTime.Today;
           return View(admin);
      }
