    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(ViewModel.ViewModelStudents student)
    {
        if (ModelState.IsValid)
        {
             // save changes and redirect
             return RedirectToAction("Index");
        }
        else
        {
            using (DB = new StudentContext())
            {
                ViewBag.StudentCLassList = new SelectList(DB.StudentClasses.ToList(), "ID", "ClassName");         
            }
    
            return View(student);
        }
    }
