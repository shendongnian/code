    var vm = new ViewModel();
    vm.Customers = _customerService.All()
                       .Select(x => new SelectListItem {
                           Value = x.CustomerID.ToString(),
                           Text = x.FirstMidName + " " + x.LastName
                       })
                       .ToList();
    return View(vm);
