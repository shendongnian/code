    [HttpPost]
    public ActionResult AddBuilding(AddBuildingViewModel buildingModel)
    {
        if (!ModelState.IsValid)
        {
            ...
            return PartialView("AddView", modelError);
        }
        ...
        return PartialView("SuccessView", model);
    }
