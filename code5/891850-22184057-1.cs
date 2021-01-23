    public List<Address> GetMatchingDeliveryAddresses(string keyword)
    {
      using( var context = new MyEntitiesContext())
      {
        List<Address> addressList = new List<Address>();
        foreach (var c in context.Customers)
        {
            var result = c.Address.Where(a => (a.LastName.Contains(keyword) || a.Company.Contains(keyword)) && a.IsDeliveryAddress == true)
                                                    .OrderByDescending(a => a.DateEffective)
                                                    .FirstOrDefault();
            System.Console.WriteLine("PRE Name: " + result.LastName);
        }
        foreach (var c in context.Customers)
        {
            var result = c.Address.Where(a => (a.LastName.Contains(keyword) || a.Company.Contains(keyword)) && a.IsDeliveryAddress == true)
                                                    .OrderByDescending(a => a.DateEffective)
                                                    .FirstOrDefault();
            System.Console.WriteLine("POST Name: " + result.LastName);
        }
    }
