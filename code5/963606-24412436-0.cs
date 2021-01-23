    public ActionResult BundleStatusRead() 
    { 
    DataAccessAdapter adapter = new DataAccessAdapter();
    EntityCollection allBundles = new EntityCollection(new CarrierBundleEntityFactory());
    adapter.FetchEntityCollection(allBundles, null);  
    var results = allBundles;
    return View(results); }
