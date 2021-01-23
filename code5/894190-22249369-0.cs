    var prices = _db.MenuOptions
                    .Where(o => orderItems.Keys.Contains(o.Id))
                    .Select(o => new { o.Id, o.Price })
                    .ToDictionary(o => o.Id, o => o.Price);
    Session["price"] = orderItems.Sum(oi => oi.Value * prices[oi.Key]);
    
