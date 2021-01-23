    //here you implicitly cast value of type DbSet<Customer>
    //to IQueryable<Customer>, which is OK
    IQueryable<Customer> query = _db.Products; 
    if (bool) {
      //here you're assigning a value of type IQueryable<Customer>
      //to a variable of the same type, which is also OK
      query = query.Where(p => p.Id == id); 
    }
