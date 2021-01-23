       var query = from c in north.Customers   
                   orderby c.CustomerID
                   select new
                   {
                      customer = c,
                      orders = c.Orders
                   };
            foreach (var item in query)
            {
                Console.WriteLine(item.customer.CompanyName);
                foreach (var ord in item.orders)
                {
                    Console.WriteLine(ord.OrderDate + " " + ord.OrderID);
                }
                Console.WriteLine("");
            } 
