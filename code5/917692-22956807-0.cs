    public Employer Controller
           {
             public ActionResult Timesheet()
             {
              GetTimesheetList model = new GetTimesheetList();
              model.GetTimesheetDetails = new List<TimesheetModel>();
               return View(model);
             }
           }
