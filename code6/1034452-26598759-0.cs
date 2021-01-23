    public ActionResult Create([Bind(Include="Columns")] Tv tv)
        {
            if (ModelState.IsValid)
            {
               try
               {
                db.Tv.Add(tv);
                int num = db.SaveChanges();
                if (num == 0)
                   prompt user
                return RedirectToAction("Index");
               catch (OptimisticConcurrencyException)
            {
            }
            }
    
            return View(tv);
        }
