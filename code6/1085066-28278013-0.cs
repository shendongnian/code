    public ActionResult Index()
    {
         var viewModel  = PatientListViewModel();
    
    // Get list of patients from DB or whereever....
         viewModel.PatientList = new List<Patients>();
    // Another Example:
    viewModel.CustomerList = new List<Cusotmer>();
        
    return View(viewModel);
    
    }
