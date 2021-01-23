        public static List<Client> GetClientsByFilter(string search, string propertyName)
        {
            using (var dbContext = new LibDbContext())
            {     
                List<Client> clients;
                
                  switch (propertyName)
                  {
                    case "LastName":
                      clients = dbContext.Clients
                          .Where(item => item.LastName.Contains(search))
                          .ToList();
                    break;
                    case "FirstName":
                      clients = dbContext.Clients
                          .Where(item => item.FirstName.Contains(search))
                          .ToList();
                    break;
                  }
               return clients;
            } 
