    public ActionResult Index()
    {
        var addressesViewModel = new AddressesViewModel();
        addressesViewModel.Addresses = new List<AddressViewModel>() { 
            new AddressViewModel{
                Street = "some road", 
                StateSelected = "PA"
            },
            new AddressViewModel{
                Street = "some other road", 
                StateSelected = "NJ"
            }
       };
            foreach (var item in addressesViewModel.Addresses)
            {
                if (item.StateSelected != null)
                {
                    item.States.First(x => x.Value == item.StateSelected).Selected = true;
                }
            }
       return View(addressesViewModel);
    }
