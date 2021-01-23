    var x = (from o in Package.PackageProducts
            orderby o.SortOrder
            select new { o.Id, o.SortOrder }).ToList();
    // Modify SortOrder in this collection x
    ...
    // Save x back to the database
    foreach(y in x)
    {
        var p = new PackageProduct { Id = y.Id, SortOrder = y.SortOrder }); // stub
        db.PackageProducts.Attach(p);
        db.Entry(p).Property(p1 => p1.SortOrder).Modified = true;
    }
    db.SaveChanges();
