    using (var db = new TempModelsContext())
    {
        var cst = new Customer { Name = "Customer1", 
                                 Card = new Amex { Number = "Amex" } };
        db.Customers.Add(cst);
        db.SaveChanges();
    }
    using (var db = new TempModelsContext())
    {
        var cst = db.Customers.Include(c => c.Card).Single(c => c.CustomerId == 1);
        cst.Card = new Visa { Number = "Visa" };
        db.SaveChanges();
    }
