    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Patient pat)
    {
        ViewModel vm = new ViewModel();
        DentistEntities db = new DentistEntities();
    
    
        if (ModelState.IsValid)
        {
    
            db.Patients.Add(pat);
            db.SaveChanges();
        }
    
        vm.VmPatient = pat;
        return View(vm);    
    }
