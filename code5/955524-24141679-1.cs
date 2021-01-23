    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult UpdateEnvironments([DataSourceRequest] DataSourceRequest dsRequest, Environment environment)
    {
        environment.ModifiedBy = userName;
        var updatedRecords = null;//1
        if (environment != null && ModelState.IsValid)
        {
            if (environment.EnvironmentID != 0)
            {
                var toUpdate = xgr.EnviromentRepository.ListAll().FirstOrDefault(p => p.EnvironmentID == environment.EnvironmentID);
                TryUpdateModel(toUpdate);
                updatedRecords = xgr.EnviromentRepository.ListAll();//2 -- you might need to add "ToList()", depending on your implementation
            }
            xgr.EnviromentRepository.Save(environment);
        }
        return Json(updatedRecords.ToDataSourceResult(request, ModelState));//3
    }
