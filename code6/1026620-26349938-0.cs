    [HttpPost, ActionName("removeresponsible")]
    public ActionResult removeresponsibleaction(IEnumerable<Responsible> models)
    {
        foreach(var model in models)
        {
            Responsible responsible = db.Responsibles.Single(x => x.responsible_id == model.responsible_id);
            db.Responsibles.Remove(responsible);
        }
        db.SaveChanges();
        ViewBag.responsible = db.Responsibles.ToList();
        return View("responsiblemanager");
    }
