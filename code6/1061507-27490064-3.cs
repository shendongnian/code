    public ActionResult FillListBoxes()
    {
        ViewModel myViewModel = new ViewModel();
        
        ...
        myViewModel.device = new List<SelectListItem>();
        foreach (var device in tempObjects.Select(obj => obj.device).Distinct().ToList()) {
            myViewModel.device.Add(new SelectListItem { Text = device, Value = device });
        // das gleiche für myViewModel.type entsprechend
        return View(myViewModel);
    }
