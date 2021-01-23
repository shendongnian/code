    var c = _investments
        .Where(i => i.ID == investmentName.ToUpper())
        .Aggregate(
            new { Price = 0, TotalQty = 0 },
            (total, i) => new 
                          { 
                              Price = total.Price + i.InitialPrice * i.Qty,
                              TotalQty = total.TotalQty + i.Qty
                          },
            i => i.Price / i.TotalQty);
