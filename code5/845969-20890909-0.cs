    public ActionResult GetStates(string countryCode)
    {
        var states = _statesService.GetStatesByCountry(countryCode)
                         .OrderBy(x => x.Name.ToUpper());
        return Json(states.Select(x => new { value = x.Code, text = x.Name }));
    }
