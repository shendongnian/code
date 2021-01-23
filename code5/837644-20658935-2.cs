    [HttpPost]
    public ActionResult Delete(SomeModel model)
    {
        /* Delete the entity from database */
        ....
    
        return RedirectToAction("Index");
    }
