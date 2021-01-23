    public List<OrderEntity> getCustomerOrders(int customerId)
    {
        var data = from c in Orders
                   where c.CustomerID == customerId
                   group c by new { c.CustomerID, c.ItemID } into g
                   select new OrderEntity () {
                      CustomerID = g.Key.CustomerID,
                      ItemID =  g.Key.ItemID,
                      Quantity = g.Sum(x => x.Quantity) 
                   };
        return data.ToList();
    }
