     var list1 = new List<OrderProduct>()
                {
                    new OrderProduct(1, "M1", 100, "Text Here"),
                    new OrderProduct(2, "M3", 20, "Text Here"),
                    new OrderProduct(3, "M1", 30, "Text Here"),
                    new OrderProduct(4, "M5", 50, "Text Here"),
                };
            var list2 = new List<OrderSold>()
                {
                    new OrderSold(1, "M1", 10),
                };
             
     var result = list1.GroupJoin(
                    list2,
                    product => new { product.Order, product.Material },
                    sold => new { sold.Order, sold.Material},
                (p, g) => g
            .Select(c => new ListSell
                {
                    Order = p.Order,
                    Material = p.Material,
                    TotalQuantity = p.TotalQuantity,
                    Description = p.Description,
                    QuantitySell = c.QuantitySell
                })
            .DefaultIfEmpty(new ListSell
                {
                    Order = p.Order,
                    Material = p.Material,
                    TotalQuantity = p.TotalQuantity,
                    Description = p.Description,
                    QuantitySell = 0
                }))
            .SelectMany(g => g);
        }
