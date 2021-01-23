    static void Main(string[] args)
    {
        Product product = new Product
        {
            Id = 1,
            Number = 1,
            Description = "TheFirstProduct",
        };
        OrderDetail detail = new OrderDetail 
        {
            Id = 1,
            OrderId = 1,
            Product = product,
        };
        Console.WriteLine(detail.Product);
        Console.ReadLine();
    }
