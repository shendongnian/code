    public ActionResult Index()
    {
        var empList = new List<EmployeeData>();      
        EmployeeData tempvar = new EmployeeData();
        tempvar.employeeID = 40;
        tempvar.employeeName = "Amit";
        tempvar.dateOfBirth = (Convert.ToDateTime("02-02-2012")).Date;
        tempvar.dateOfJoining = (Convert.ToDateTime("02-02-2012")).Date;
        tempvar.supervisor = "Head";
        empList.Add(tempvar);
        return View("Index",empList);
    }
    
    public PartialViewResult Insert()
    {
        if (Request.IsAjaxRequest())
        {
            return PartialView("Insert", new EmployeeData());
        }
        return PartialView("Insert");
    }      
    [HttpPost]
    public ActionResult InsertForm(EmployeeData model)
    {       
        //do code for save
        return Json(new {Message="Successfully saved"});
    }
