    private static void OrderingTest()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Test1Context>());
            var context = new TestContext();
            context.Customers.Add(new Company { Denomination = "A" });
            context.Customers.Add(new Company { Denomination = "C" });
            context.Customers.Add(new Person { LastName = "B" });
            context.Customers.Add(new Person { LastName = "D" });
            context.SaveChanges();
            var a = (from customer in context.Customers.OfType<Company>()
                     select new CustomerInfo { Name = customer.Denomination, Customer = customer }
                    )
                    .Union
                    (from customer in context.Customers.OfType<Person>()
                     select new CustomerInfo { Name = customer.LastName, Customer = customer }
                     );
            var customerInfoList = a.OrderBy(item => item.Name);
            var customers = customerInfoList.ToList().Select(item => item.Customer);
        }
        class CustomerInfo
        {
            public string Name { get; set; }
            public Customer Customer { get; set; }
        }
