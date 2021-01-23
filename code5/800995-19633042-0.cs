    IEnumerable<Customer> customers = from customer in db.Customer 
        select CustomerID,   Customername;
    using(TextWriter sw = new StreamWriter("test.txt", true))
    {
        foreach (var c in customers)
        {
            sw.WriteLine(c.ToString());
        }
    }
