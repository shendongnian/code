    public ActionResult Index()
    {
        Provider providerList = new Provider();
        IList<Provider> providers = DAL.GetListofProviders.ToList();
        return View(providers);
    }
