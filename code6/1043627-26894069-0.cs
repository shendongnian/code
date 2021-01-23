    public void ParsePage(Product p)
    {
        using (var repo = new DataRepository())
        {
            //Grab related page report
            PageReport pr = repo.PageReports.Where(c => c.ThePageType == "Product").FirstOrDefault(c => c.ThePageTypeID == p.ProductID);
            //Do some stuff
     
            //Save
            repo.SavePageReport(pr);
        }
    }
