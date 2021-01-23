    public void UpDate()
    {
        Customers.Clear();
        foreach(var customer in context.Customers.OrderBy(c => c.Name)) Customers.Add(customer);
    }
