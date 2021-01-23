    [Route("student/xApplication/{personId?}")]
    [HttpGet]
    public ActionResult xApplication(int? personId)
    {
        if (personId == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Person person = db.People.Find(personId);
        if (person == null)
        {
            return HttpNotFound();
        }
    
        // Prepare ViewModel to pass to view, based on personId
        PersonViewModel personVModel = new PersonViewModel(); // ApplicationStatusList is generated here
        personVModel.Person = person;
    
        // Get XApplication Data
        var xApps = from a in db.XApplications where a.personId == personId select a;
    
        XApplication personXApplication = null;
        if (xApps.Count() > 0)
        {
            personXApplication = xApps.First();
        }
        personVModel.XApplications = personXApplication;
    
        return View(personVModel);
    }
