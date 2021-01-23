    public ActionResult SetDropDowns(string provinceId, string countryId)
    {
        IEnumerable<SelectListItem> CountryItems = BusinessAPI.CountryManager.GetAllCountries().Select(ci => new SelectListItem
        {
            Value = ci.Id.ToString(),
            Text = ci.Name,
			Selected = countryId == ci.Id.ToString() // if match the condition is selected
        });
        ViewBag.CountryItems = CountryItems;
        int countId = 0;
        if (countryId == "null")
            countryId = string.Empty;
        if (TempData["CountryId"] == null)
        {
            if (!string.IsNullOrEmpty(countryId))
            {
                countId = Convert.ToInt32(countryId);
                TempData["CountryId"] = countId;
            }
        }
        else
            countId = Convert.ToInt32(TempData["ProvinceId"]);
        IEnumerable<SelectListItem> ProvinceItems = BusinessAPI.ProvinceManager.GetAllProvincesByCountryId(Convert.ToInt32(countId)).Select(ci => new SelectListItem
        {
            Value = ci.Id.ToString(),
            Text = ci.Name
			Selected = provinceId == ci.Id.ToString() // if match the condition is selected
        });
        ViewBag.ProvinceItems = ProvinceItems;
        int provId = 0;
        if (provinceId == "null")
            provinceId = string.Empty;
        if (TempData["ProvinceId"] == null)
        {
            if (!string.IsNullOrEmpty(provinceId))
            {
                provId = Convert.ToInt32(provinceId);
                TempData["ProvinceId"] = provId;
            }
        }
        else
            provId = Convert.ToInt32(TempData["ProvinceId"]);
        IEnumerable<SelectListItem> CityItems = BusinessAPI.CityManager.GetAllCitiesByProvinceId(provId).Select(ci => new SelectListItem
        {
            Value = ci.Id.ToString(),
            Text = ci.Name
        });
        ViewBag.CityItems = CityItems;
        return View("Register");
    }
