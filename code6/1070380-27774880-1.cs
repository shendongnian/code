    public ActionResult Personal(StudentModel student)
    {                          
           TempData["student"] = student;
           return RedirectToAction("nextStep", "ControllerName");          
    }
    
    public ActionResult nextStep()
    {      
           StudentModel model= (StudentModel) TempData["student"];
           return View(model);
    }
