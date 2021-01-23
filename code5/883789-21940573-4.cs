    var query = ((from s in db.Pricelists
                         select s.CustId).Distinct()).ToList();
    int i = 1;
    List<Pricelist> CustomerList = new List<Pricelist>();
    foreach (var c in query)
    {
        int cust = c;
        Pricelist p = new Pricelist(i, cust);
        CustomerList.Add(p);
        i++;
    }
        model.PriceList=result of your query
    
    return View("ViewName",model); 
