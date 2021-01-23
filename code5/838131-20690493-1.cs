    orders = Context.orders
        .GroupJoin(
            Context.suborders,
            o => o.id,
            so => so.order_id,
            (o, so) => new { order = o, suborders = so })
        .ToList()
        .Select(r => new Order
        {
            id = r.order.id,
            name = r.order.name,
            suborders = r.suborders.Select(so => new Suborder
            {
                id = so.id,
                name = so.name
            }.ToList()
        }).ToList();
