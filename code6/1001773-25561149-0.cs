    [HttpPost]
    public ActionResult AddEmployee(EmployeeList ListOfEmployees1)
    {
      if (ModelState.IsValid)
      {
        ....
      }
      return View(ListOfEmployees1);
    }
