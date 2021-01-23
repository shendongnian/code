    internal class OrderDetailCollection : List<OrderDetail>
    {
        internal OrderDetailCollection() {}
        internal OrderDetailCollection(IEnumerable<OrderDetail> src)
        {
            AddRange(src);
        }
    }
    List<Order> lineItems = new List<Order>
    (
        from list in xDoc.Descendants(ns + "orders")
        from item in list.Elements(ns + "order")
        where item != null
        select new Order
        {
            OrderId = (string)item.Attribute("orderId"),
            OrderDetails = new OrderDetailCollection(
                from detail in item.Elements("orderDetail")
                select new OrderDetail {
                    ItemName = (string)detail.Attribute("itemName"),
                    Quantity = (int)detail.Attribute("quantity")
                }
            )
         }
    );
