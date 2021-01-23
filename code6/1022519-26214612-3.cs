            var customers = new List<Customer>() { new Customer() {Name = "Mick", Surname = "Jagger"}, new Customer() {Name = "George", Surname = "Clooney"},new Customer() {Name = "Kirk", Surname = "DOuglas"}};
            var locker = new object();
            // Let's get all of the items for all of these customers
            var items = customers
                .AsParallel()
                .SelectMany(x =>
                {
                    lock (locker)
                    {
                        Console.WriteLine("Requesting: " + x.Name + " - " + DateTime.Now);
                        Thread.Sleep(3000);
                        return new List<CustomerItem>();
                    }
                    
                })
                .ToList();
