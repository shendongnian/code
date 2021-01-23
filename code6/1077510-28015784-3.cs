    var cst = db.Customers.Include(c => c.Card).Single(c => c.CustomerId == 1);
    db.Cards.Remove(cst.Card);
    db.SaveChanges();
    
    cst.Card = new Visa { Number = "Visa" };
    db.SaveChanges();
