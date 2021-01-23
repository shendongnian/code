    [HttpPost]
    public ActionResult Create(QuestionnaireViewModel vm)
    {
        if (ModelState.IsValid)
        {
            // map the viewmodel properties onto the domain model object here
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(questionnaire);
    }
