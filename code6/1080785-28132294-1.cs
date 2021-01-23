    public ActionResult Edit(int id)
    {
      TenancyVM model = new TenancyVM();
      model.TenancyID = jobService.GetTenancyForJob(id);
      ConfigureEditModel(model);
      return View(model);
    }
    // Gets called in the GET and in POST method if the view is returned
    private void ConfigureEditModel(TenancyVM model)
    {
      var tenancies = _jobService.GetAllJobTenancies();
      model.TenancyList = new SelectList(tenancies , "Id", "JobTenancyName");
    }
