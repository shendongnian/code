    public ActionResult Index()
    {
        MyViewModel mvm = new MyViewModel();
        mvm = Initialize(mvm);
        return View(mvm);
    }
    public MyViewModel Initialize(MyViewModel mvm)
    {
        if (_CurrenciesList == null)
            mvm.CurrenciesList = GetCurrencyList();
        else
            mvm.CurrenciesList = _CurrenciesList;
        if (_CountriesList == null)
            mvm.CountriesList = Get CountriesList();
        else
            mvm.CountriesList = _CountriesList;
        return mvm;
    }
    private static SelectListItem[] _CurrenciesList;
    private static SelectListItem[] _CountriesList;
    /// <summary>
    /// Returns a static category list that is cached
    /// </summary>
    /// <returns></returns>
    public SelectListItem[] GetCurrenciesList()
    {
        if (_CurrenciesList == null)
        {
            var currencies = repository.GetAllCurrencies().Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.CurrencyId.ToString()
            }).ToList();
            currencies.Insert(0, new SelectListItem() { Value = "0", Text = "-- Please select your currency --" });
            _CurrenciesList = currencies.ToArray();
        }
        // Have to create new instances via projection
        // to avoid ModelBinding updates to affect this
        // globally
        return _CurrenciesList
            .Select(d => new SelectListItem()
        {
            Value = d.Value,
            Text = d.Text
        })
        .ToArray();
    }
    public SelectListItem[] GetCountriesList()
    {
        if (_CountriesList == null)
        {
            var countries = repository.GetAllCountries().Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.CountryId.ToString()
            }).ToList();
            countries.Insert(0, new SelectListItem() { Value = "0", Text = "-- Please select your country --" });
            _CountriesList = countries.ToArray();
        }
        // Have to create new instances via projection
        // to avoid ModelBinding updates to affect this
        // globally
        return _CountriesList
            .Select(d => new SelectListItem()
        {
            Value = d.Value,
            Text = d.Text
        })
        .ToArray();
    }
