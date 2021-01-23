    public ActionResult FooDetails(int id)
    {
        var foo = db.Foos.SingleOrDefault(m => m.Id == id && m.Creator == User.Identity.Name);
        if (foo == null)
        {
            return new HttpNotFoundResult();
        }
        return View(foo);
    }
