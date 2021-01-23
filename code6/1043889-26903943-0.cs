    public Client FindClient(DbKey key)
    {
      Context db = new Context();
      Client result = Extensions.Find(db.Clients, key);
      return result;
    }
