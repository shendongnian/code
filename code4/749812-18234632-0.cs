    foreach (var group in Customers.GroupBy(x => x.emailaddress))
    {
        Console.WriteLine("Customers with email address {0}", group.Key);
        foreach (var customer in group)
        {
            Console.WriteLine("  {0}", customer.Name); // Or whatever
        }
    }
