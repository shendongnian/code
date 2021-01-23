    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateMoreEntitiesAtOnce(MyEntities set)
    {
        foreach(var item in set.MyEntities) 
        {
            db.MyEntity.Add(item);
        }
        db.SaveChanges();
        return RedirectToAction("Index");
    }
