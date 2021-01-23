    [HttpGet]
    public ActionResult AddCustomer() {
        CustomerViewModel vm = new CustomerViewModel();
        vm.Title = "Mr";
        vm.ValidTitles = new SelectListItem[] { new SelectListItem("Mr", "Mr"), new SelectListItem("Mrs.", "Mrs."), new SelectListItem("Sgt.", "Sgt.") };
        return View( vm );
    }
