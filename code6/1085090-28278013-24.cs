        public ActionResult Index()
        {
            var viewModel = PatientListViewModel();
            viewModel.PatientList = new List<Patients>();
            viewModel.CustomerList = new List<Cusotmer>();
            return View(viewModel);
        }
