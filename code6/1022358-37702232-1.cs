    //initialize model db
    testdbEntities dc = new testdbEntities();
    //get employee details 
    List<Employee1> lst = dc.Employee1.ToList(); 
    //selecting the desired columns
    var subCategoryToReturn = lst.Select(S => new {
        Employee_Id = S.Employee_Id,
        First_Name = S.First_Name,
        Last_Name = S.Last_Name,
        Manager_Id = S.Manager_Id
    });
    //returning JSON
    return this.Json(subCategoryToReturn , JsonRequestBehavior.AllowGet);
