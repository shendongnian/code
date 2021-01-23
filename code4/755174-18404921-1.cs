    public ActionResult Create()
    {
    
        ViewModel1 VM1 = new ViewModel1();
        VM1.CountryID = 50;    //just pre-selecting a country id in the dropdown list
        using(AccDBEntities db = new AccDBEntities())
        {
            VM1.CountriesList = (from ct in db.Countries
                                 select ct).ToList(); 
        }
        
        return View(VM1);
    }
