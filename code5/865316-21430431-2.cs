    public ActionResult ViewMyAtdRecord()
    {
        int empId = 0; 
        int.TryParse((string)Session["Employee"], out empId); // parse variable to int
    
        if (empId > 0) // we have an employee id, lets show that record.
        {
            IEnumerable<GetAtdRecord_SpResult> MyAtdRecord = DataContext.GetAtdRecord_Sp(empId ).ToList();
            var names = (from n in DataContext.HrEmployees select n).Distinct();
            return View(MyAtdRecord);
        }
        else // we do not have an employee id, show not authorized message.
        {
            ViewBag.Message = "NOT AUTHORIZED TO VIEW THIS PAGE";
            return View();
        }
    } 
