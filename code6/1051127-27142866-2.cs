    [HttpPost]
    public ActionResult CreateEmployeeFamilyDetails(EmployeeSuperClass employeeSuperClass, string Command)
    {
         if (ModelState.IsValid)
         {
             return("some view");
         }
         else
         {
              PopulateDropDownsOnViewModel(employeeSuperClass);
              return View(employeeSuperClass);
         }
     }
