    var groupedByProductId = query.GroupBy(p => p.ProductId).Select(g => new
            {
                ProdcutId = g.Key,
                Quantities = g.Select(p => p.Quantity).ToArray()
            });
