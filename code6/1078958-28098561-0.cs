        internal class Entity
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public IEnumerable<Order> Orders { get; set; }
            internal class Order
            {
                public string Id { get; set; }
                public DateTime Date { get; set; }
            }
        }
        static void Main(string[] args)
        {
            var customers = new List<Entity>
            {
                new Entity
                {
                    Id = "test1",
                    Name = "test2",
                    Orders = new[] {new Entity.Order
                                    {
                                        Id = "testprop", 
                                        Date = DateTime.UtcNow
                                    }}
                }
            };
            var json = JObject.FromObject(new {Customers = customers});
            Console.WriteLine(json);
        }
