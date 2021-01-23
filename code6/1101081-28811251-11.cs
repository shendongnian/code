    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(CreatePatientViewModel viewModel)
    {
        // Do whatever you want with the data.
        // viewModel.User.Device.DeviceId will be given the value selected from the dropdown.
        return View(viewModel);
    }
