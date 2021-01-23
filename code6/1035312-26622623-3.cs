    public List<List<Order>> grouping()
    {           
                // List of Orders to Group
                List<Order> orderList = new List<Order>();
                orderList.Add(new Order { UserId = 1, OrderId = 2007, Email = "blah1@test.com", PostCode = 111, Country = "India" });
                orderList.Add(new Order { UserId = 2, OrderId = 2007, Email = "blah1@test.com", PostCode = 111, Country = "India" });
                orderList.Add(new Order { UserId = 3, OrderId = 2007, Email = "blah1@test.com", PostCode = 111, Country = "India" });
                orderList.Add(new Order { UserId = 4, OrderId = 2008, Email = "blah1@test.com", PostCode = 111, Country = "India" });
                orderList.Add(new Order { UserId = 5, OrderId = 2008, Email = "blah1@test.com", PostCode = 111, Country = "India" });
                orderList.Add(new Order { UserId = 6, OrderId = 2001, Email = "blah1@test.com", PostCode = 111, Country = "India" });
                
                // Grouping
                var groupedOrderList = orderList
                    .GroupBy(u => u.OrderId)
                    .Select(grp => grp.ToList()).ToList();  // Groping the Records based on the OrderId 
    
                return groupedOrderList; // The Result will be List<List<Order>>
    }
