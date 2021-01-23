    var query = _context.Set<OrderItem>()
            .Where(oi => oi.Order.ClientId == input.ClientId)
            .GroupBy(oi => oi.ProductId)
            .OrderByDescending(group => group.Sum(item => item.Quantity))
            .Take(15);
