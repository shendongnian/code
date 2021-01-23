    static void Main()
    {
        var source = new[] {
            new ReferenceProduct { Name = "def" },
            new ReferenceProduct { Name = "fooghi" },
            new ReferenceProduct { Name = "abc" }
        }.AsQueryable();
        var sorted = ReferenceProduct.OrderProducts(source, "name", "asc", "foo");
        var arr = sorted.ToArray(); 
        foreach(var item in arr) {
            Console.WriteLine(item.Name);
        }
    }
