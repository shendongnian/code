    using(var db = new Context())
    {
    
        foreach(Customer objCustomer in listCustomer)
        {
             var exists = db.Customer.FirstOrDefault(x => x.CustomerID == objCustomer.CustomerID;
        
             if( exists = null)
             {
                db.Customer.Add(objCustomer);
                
             }
             else
             {
                db.Entry(objCustomer).State = EntityState.Modified;
             }
             db.SaveChanges();
        
        }
    
    }
