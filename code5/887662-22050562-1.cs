    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Categorie categorie = db.Categories.Find(id);
        if (categorie == null)
        {
            return HttpNotFound();
        }
        return View(categorie);
    }
