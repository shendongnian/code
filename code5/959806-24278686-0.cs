     public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
     var customerList1 = new List<Customer>(new[]
            {
                new Customer {Id = 1, Name = "AAA"},
                new Customer {Id = 1, Name = "BBB"},
                new Customer {Id = 1, Name = "CCC"}
            });
            var customerList2 = new List<Customer>(new[]
            {
                new Customer {Id = 1, Name = "AAA"},
                new Customer {Id = 1, Name = "BBB"},
                new Customer {Id = 1, Name = "CCC"},
                new Customer {Id = 1, Name = "DDD"}
            });
            var commonCustomers = customerList1.Join(customerList2, x => x.Name, y=>y.Name,(a,b)=>a).ToList();
