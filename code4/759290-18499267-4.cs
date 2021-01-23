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
            //note that the cast is simpler to write than the null check in your code
            //http://msdn.microsoft.com/en-us/library/bb387049.aspx
            OrderId = (string)item.Attribute("orderId"),
            OrderDetails = new OrderDetailCollection(
                from detail in item.Descendants("orderDetail")
                select new OrderDetail {
                    ItemName = (string)detail.Attribute("itemName"),
                    Quantity = (int)detail.Attribute("quantity")
                }
            )
         }
    );
