    var groupedByProductId = query.GroupBy(p => p.ProductId).Select(g => new
            {
                ProdcutId = g.Key,
                Quantities = g.OrderBy(p => p.Date).Select(p => p.Quantity).ToArray()
            });
