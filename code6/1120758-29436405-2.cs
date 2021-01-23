    using(var db = new DataContext())
    {
    	var custs = db.Customers
    				  .Where(c => c.Active == true).ToList();
    
        if(Customers == null)
    	    Customers = new ObservableCollection<Customer>();
        foreach (var cust in custs)
        {
    	    Customers.Add(cust);
        }
    }
