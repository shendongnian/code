    [HttpPost]
    [Route("student/xApplication")]
    public ActionResult xApplication(PersonViewModel personVModel)
    {
        if (ModelState.IsValid)// Checks no errors
        {
            db.XApplications.Add(personVModel.XApplications);
            db.SaveChanges();
            return Redirect("/student/xApplication/" + personVModel.Person.id);
        }
        // repopulate ApplicationStatusList property
        personVModel.PopulateApplicationStatusList();
    
        return View(personVModel);
    }
