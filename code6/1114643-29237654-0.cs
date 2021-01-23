          public IQueryable<Entities.Customer> AllCustomerRanges(int CId, int ItemID)
            {
                var c = myDataContext.spCustomerRanges(CId, ItemID).ToList();
    
                if (c == null)
                    return null;
    
                var customers = c.Select(a => new Entities.Customer
                {
                    FirstName=a.spResultFirstName,
                    LastName = a.spResultLastName
                    //this just example conversion, change it as needed. 
                });
    
    
                return customers;
    
            }
