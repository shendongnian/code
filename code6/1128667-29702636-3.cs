    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(ViewModel.ViewModelStudents student)
    {    
        var tempResult = student.StudentCLass.ID;
    
    ViewBag.StudentCLassList = new SelectList(DB.StudentClasses
                   .Select(sc => new ViewModelClass 
                   { 
                       ID = sc.ID, 
                       ClassName = sc.ClassName 
                   }).ToList(), "ID", "ClassName"); 
    
        return RedirectToAction("Index");
    }
