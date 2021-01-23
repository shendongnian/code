    public ActionResult Detail(int id)
    {
        var project = Projects.Where(p => p.Id == id).FirstOrDefault();
        return View(project);
    }
