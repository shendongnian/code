    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(ViewModel.ViewModelStudents student)
    {    
        var tempResult = student.StudentCLass.ID;
    
        PopulateDropDownList(); 
    
        return RedirectToAction("Index");
    }
