      public ActionResult Details(string department)
        {
            var item = db.Items.Find(department);
            return View(item);
        }
