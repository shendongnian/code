    public ActionResult Create(int ApplicantID) // assume you must have a custom route for this?
    {
      ApplicantApplicationRecordingsViewModel viewModel = new ApplicantApplicationRecordingsViewModel();
      Applicant applicant = dbContext.Applicants.Find(ApplicantID);
      viewModel.Applicant = applicant;
      viewModel.Title = string.Format("Create a new application for {0} {1} {2}", applicant.title, applicant.firstName, applicant.lastName);
      viewModel.Recordings = getViewModel(dbContext.Recordings.ToList(), dbContext); // not sure what this is?
      viewModel.UsageTypeSelectList = new SelectList(dbContext.UsageTypes.OrderBy(ut => ut.UsageTypeName), "UsageTypeID", "UsageTypeName");
      viewModel.UsageEndAppSelectList = new SelectList(dbContext.UsageEndApps.OrderBy(uea => uea.UsageEndAppName), "UsageEndAppID", "UsageEndAppName");  
      return View(viewModel);
    }  
