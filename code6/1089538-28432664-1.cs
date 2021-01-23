    public MyController
    {
        private IMyService myService;
        public MyController(IMyService myService)
        {
            this.myService = myService;
        }
        // Showing create/edit form
        [HttpGet]
        public ActionResult CreateSomething()
        {
            // Create Empty view model. new SomeViewModel(); for example.
            // Get some nomenclatures for dropdowns etc. through the service (if needed).
            // return View(viewModel);
        }
        // Processing the post request
        [HttpPost]
        public ActionResult CreateSomething(SomeViewModel viewModel)
        {
            // Check validity of viewModel (ModelState.IsValid)
            // If not valid return View(viewModel) for showing validation errors
            // If valid map the viewModel to Model (through AutoMapper or custom mapping)
            // Call myService CreateSomething method.
            // Redirect to page with details.
        }
    }
