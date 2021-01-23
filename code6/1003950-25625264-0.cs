    ProductTotals = db.Products.Where(p => p.EventID == ev.Id).Select(p => new ProductSummaryViewModel
    {
        ProductID = p.ProductID,
        ProductName = p.Name,
        Registrations = p.Registrations.AsQueryable() // AsQueryable()
                         .Where(ExpressionConstants.IsAttending).Count(),
    })
