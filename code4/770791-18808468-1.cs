    var customers = customerTable.ToList();
    foreach (Customer customer in customers)
    {
        foreach (Purchase purchase in customer.Purchases)
        {
            Console.WriteLine("My data here...");
        }
    }
