    public static List<Client> GetClientsByFilter(string search, 
                                                  Func<Client, string> propertyGetter)
    {
      //it's Entity Framework context
      using (var dbContext = new LibDbContext())
      {
        List<Client> clients;
        clients = dbContext.Clients
                           .Where(item => propertyGetter(item).Contains(search))
                           .ToList();
      }
      return clients;
    }
