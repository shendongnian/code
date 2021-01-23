    public ActionResult GetStates(short? countryId)
    {
        if (!countryId.HasValue)
        {
            return Json(new List<object>(), JsonRequestBehavior.AllowGet);
        }
            
        var data = GetAllStatesForCountry(countryId.Value).Select(o => new { Text = o.StateName, Value = o.StateId });
        return Json(data, JsonRequestBehavior.AllowGet);
    }
