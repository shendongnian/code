    IQueryable<Supplier> query = Context.Suppliers;
    
    if (!String.IsNullOrEmpty(nameMatch))
       query = query.Where(s => s.SupplierName == nameMatch);
    if (!String.IsNullOrEmpty(contactMatch))
       query = query.Where(s => s.ContactName == contactMatch);
    
    // etc
    return query.AsEnumerable();
