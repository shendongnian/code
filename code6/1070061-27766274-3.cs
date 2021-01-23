    public static List<Client> GetClientsByFilter(string search, string propertyName)
    {
       //it's Entity Framework context
       using (var dbContext = new LibDbContext())
       {
            List<Client> clients;
                 clients = dbContext.Clients
                .Where(GetExpression<Client>(propertyName, search)) // Now using Marc's method
                .ToList();
        }
     return clients;
