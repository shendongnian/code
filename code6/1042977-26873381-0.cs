    public ActionResult Create(Klant klant)
    {
        if (ModelState.IsValid)
        {
            if(db.Klanten.Any(k => k.Username == klant.Username)
               ModelState.AddModelError("Firma", "Firma already exists");
            else
            {
               db.Klanten.Add(klant);
               db.SaveChanges();
               return RedirectToAction("Index");
            }
        }
        return View(klant);
    }
