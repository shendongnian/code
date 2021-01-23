    public ActionResult Subjects() {
        var model = new SubjectsViewModel();
        model.Subjects = db.Subjects;
        return View(model);
    }
