    var query = _context.Set<OrderItem>()
                .Where(oi => oi.Order.ClientId == input.ClientId)
                .GroupBy(oi => oi.ProductId)
                .Select(group => new { ProductId = group.Key, Description = group.First().Description, Sum = group.Sum(item => item.Quantity })
                ).Take(15);
