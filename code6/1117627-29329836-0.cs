    var resultByDesc = db.Entities
                       .OrderByDescending(o => o.DateTime)
                       .Skip(page * itemsPerPage)
                       .Take(itemsPerPage)
                       .ToList();  // important! eager loading!
    // it will be executed in your client side, not SQL.
    var actualResult = resultByDesc.Reverse();
