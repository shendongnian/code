    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Try to reuse same Instance:");
            using (var ctx = new AdventureWorksEntities())
            {
                List<int> ids = new List<int> {1, 2, 3}; 
                Product p1 = new Product();
                Product reference = p1;
                Product p2;
                Console.WriteLine("Start Count: {0}", ctx.Products.Count());
                foreach (var id in ids)
                {
                    p1.ProductID = id;
                    p2 = ctx.Products.Add(p1);
                    Console.WriteLine("p1 = p2 ? {0}", p1 == p2);
                    Console.WriteLine("p2 = reference? {0}", p2 == reference);
                    Console.WriteLine("State: {0}", ctx.Entry(p1).State);
                    var changes = ctx.ChangeTracker.Entries<Product>();
                    Console.WriteLine("Change Count: {0}", changes.Count());
                }
            }
            Console.WriteLine();
            Console.WriteLine("Distinct Instances:");
            using (var ctx = new AdventureWorksEntities())
            {
                List<int> ids = new List<int> { 1, 2, 3 };
                Product p2;
                foreach (var id in ids)
                {
                    var p1 = new Product {ProductID = id};
                    p2 = ctx.Products.Add(p1);
                    Console.WriteLine("p1 = p2 ? {0}", p1 == p2);
                    Console.WriteLine("State: {0}", ctx.Entry(p1).State);
                    var changes = ctx.ChangeTracker.Entries<Product>();
                    Console.WriteLine("Change Count: {0}", changes.Count());
                }
            }
    
            Console.ReadLine();
        }
    }
