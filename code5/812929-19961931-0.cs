    [HttpPost]
    public ActionResult GetVisitorLogCreateVisitorForm(DriversLicenseForm CardData)
    {
        ModelState.Clear();
        var form = visitorService.GetForm(CardData);
        return PartialView("Form", form);
    }
