    var query = db.Orders.ToList().Select(o => new {
    o.OrderNumber,
    o.Name,
    o.State,
    OrderDate = Convert.ToDateTime(o.OrderNumber)
    }).ToList();
