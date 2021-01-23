    var model = new AddressViewModel();
    ViewBag.CitySortParm = String.IsNullOrEmpty(sortOrder) ? "City_desc" : "";
    switch (sortOrder)
    {
        case "City_desc":
            model = this.UnitOfWork.AddressRepository.Get().OrderBy(a => a.City);
            break;
    }
    return View(model);
