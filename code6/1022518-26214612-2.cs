              var customers = new List<Customer>() { new Customer() {Name = "Mick", Surname = "Jagger"}, new Customer() {Name = "George", Surname = "Clooney"},new Customer() {Name = "Kirk", Surname = "DOuglas"}};
              var items = customers
                .AsParallel()
                .SelectMany(x =>
                {
                     Console.WriteLine("Requesting: " + x.Name + " - " + DateTime.Now);
                     Thread.Sleep(3000);
                     return new List<CustomerItem>();
                    
                })
                .WithDegreeOfParallelism(1)
                .ToList();
