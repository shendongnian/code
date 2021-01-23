    public List<OrderEntity> getCustomerOrders(int customerId)
        {
            var data = from c in Orders
                       where c.CustomerID == customerId
                       group c by new { c.CustomerID, c.ItemID,c.Description,c.POST,c.Cost } into g
                       select new OrderEntity () {
                          CustomerID = g.Key.CustomerID,
                          ItemID =  g.Key.ItemID,
                          Quantity = g.Sum(x => x.Quantity),
                          Description = g.Key.Description,
                          POST = g.Key.POST,
                          Cost = g.Key.Cost 
                       };
            return data.ToList();
        }
