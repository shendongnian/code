    public static XDocument ConvertToXDocument(List<Order> orders)
    {
        XDocument doc =
            new XDocument(
                 new XElement("Orders",orders.Select(o =>
                     new XElement("Order",
                          new XAttribute("OrderNo", o.OrderNumber),
                          new XAttribute("ProductId", o.ProductId)))));
        return doc;
    }
