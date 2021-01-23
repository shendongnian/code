    [HttpPost]
    public virtual ActionResult Edit(EditViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            SaveSettings(viewModel);
            return RedirectToAction(MVC.Settings.Edit());
        }
        return View(viewModel);
    }
    
    private void SaveSettings(EditViewModel viewModel)
    {
        var settings = MapEditViewModelToDomainModels(viewModel);
        var saveDomainModel = new SaveDomainModel
        {
            DomainModels = settings,
            SettingType = SettingTypeEnum.Application
        };
        _settingsService.SaveSettings(saveDomainModel);
    }
