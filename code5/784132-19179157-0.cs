     OrderItems = new List<OrderItem>(
        from current in i.Element("OrderItems")
        select new OrderItem() {
            Product = new Product()
            {
                ID = new Guid(current.Element("ID").Value),
                UnitPrice = current.Element("UnitPrice").Value.To<decimal>()
            },
            Quantity = current.Element("Quantity").Value.To<int>(),
            TotalPrice = current.Element("TotalPrice").Value.To<decimal>()
        }
     )
