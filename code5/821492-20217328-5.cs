    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateMoreEntitiesAtOnce(MoreEntities set)
    {
        foreach(var item in set.MyEntities) 
        {
            db.MyEntity.Add(item);
        }
        db.SaveChanges();
        return RedirectToAction("Index");
    }
