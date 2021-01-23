    static void Main(string[] args)
    {
        Product res=new Product();
        Console.WriteLine("Enter the name of the product");
        string pname = Console.ReadLine();
        res = products.SingleOrDefault(x=>x.Name == ProductName);
    }
