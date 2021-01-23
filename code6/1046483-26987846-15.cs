       public ActionResult Index()
        { 
        
        AdminHomeViewModel model = new AdminHomeViewModel();
        
          var result1 = (from x in db.Projects
                              where x.Project_Status == "Ongoing"
                              select new Project(){
                                  Project_Id = x.Project_Id ,
                                  Project_Name = x.Project_Name,
                                  ... //all other assignments goes here
                              }).ToList();
    
    var result2 = (from x in db.Projects
                              where x.Project_Status == "blah blah"
                              select new Project(){
                                  Project_Id = x.Project_Id ,
                                  Project_Name = x.Project_Name,
                                  ... //all other assignments goes here
                              }).ToList();
    
    var result3 = (from x in db.Employee
                              where x.AnyCondition == "blah blah"
                              select new Employee(){
                                  Employee_Id = x.Employee_Id ,
                                  Employee_Name = x.Employee_Name,
                                  ... //all other assignments goes here
                              }).ToList();
        
        model.Ongoing = result1;
        model.NYA  = result2;
        model.Free = result3;
        
            
        return View(model);
    
           
        }
