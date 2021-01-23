    foreach (Toy toy in toys)
    {
        Console.WriteLine("toy: " + toy.Name);
        Console.WriteLine("supplier: " + toy.Supplier);
        Console.WriteLine("cost: " + toy.Cost + " (" + toy.Currency + ")");
        Console.WriteLine();
    }
