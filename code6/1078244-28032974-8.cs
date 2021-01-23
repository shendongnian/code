    public static XDocument ConvertToXDocument(IEnumerable<Order> orders) //accept IEnumerable of orders because don't care if it's a list or not as long as we can enumerate over it
    {
        XDocument doc =
            new XDocument(
                 new XElement("Orders",orders.Select(o =>
                     new XElement("Order",
                          new XAttribute("OrderNo", o.OrderNumber),
                          new XAttribute("ProductId", o.ProductId)))));
        return doc;
    }
