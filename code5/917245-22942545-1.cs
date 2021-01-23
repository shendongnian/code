    [HttpPost]
    public ActionResult StepFinal(StepFinalViewModel)
    {
        if (ModelState.IsValid)
        {
            var myEntity = new MyEntity();
            
            var step1 = Session['Step1'] as Step1ViewModel;
            myEntity.SomeField = step1.SomeField;
            // ... repeat for field in view model, then for each step
            db.MyEntities.Add(myEntity);
            db.SaveChanges();
            Session.Remove('Step1');
            // repeat for each step in session
            return RedirectToAction("Success");
        }
        // errors
        return View(model);
    }
