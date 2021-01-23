     class CustomerData
     {
        public string CustomerName { get; set; }
        public int OrderCount { get; set; }
     }
    var query = from c in north.Customers
                join o in north.Orders on c.CustomerID equals o.CustomerID 
                group o by o.Customer.CompanyName  into g                        
                select new CustomerData
                {
                   CustomerName =  g.Key,
                   OrderCount = g.Count()
                }
                into c
                orderby c.OrderCount descending
                select c
                ;
            foreach (var item in query)
            {
                Console.WriteLine(item.CustomerName + " " + item.OrderCount);
                
            }
