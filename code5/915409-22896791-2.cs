    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""1"": {
                    ""orders.orderid"":""538"",
                    ""entity.customerid"":""109"",
                    ""entity.entityid"":""538"",
                },
                ""2"": {
                    ""orders.orderid"":""536"",
                    ""entity.customerid"":""108"",
                    ""entity.entityid"":""536"",
                },
                ""recsindb"":""2"",
                ""recsonpage"":""2""
            }";
            RootObject obj = JsonConvert.DeserializeObject<RootObject>(json);
            foreach (var kvp in obj.Orders)
            {
                Console.WriteLine("Order #" + kvp.Key);
                Console.WriteLine("   OrderID " + kvp.Value.OrderID);
                Console.WriteLine("   CustomerID " + kvp.Value.CustomerID);
                Console.WriteLine("   EntityID " + kvp.Value.EntityID);
            }
        }
    }
