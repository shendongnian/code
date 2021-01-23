    List<Order> lineItems = new List<Order>
    (
        from list in xDoc.Descendants(ns + "orders")
        from item in list.Elements(ns + "order")
        where item != null
        select new Order
        {
            OrderId = (string)item.Attribute("orderId"),
            OrderDetails = (
                from detail in item.Descendants("orderDetail")
                select new OrderDetail {
                    ItemName = (string)detail.Attribute("itemName"),
                    Quantity = (int)detail.Attribute("quantity")
                }
            ).ToList()
         }
    );
