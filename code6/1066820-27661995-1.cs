    public static void AddAccount ()
    {
      var db = new DALEntities();
      Account account = new Account();
    
      db.Account.Add(account);
      db.SaveChanges();
      var newid = account.AccountId;
      if (MySession.Current._ClientId != null)
      {
          Client client =  db.Client.SingleOrDefault(d => d.ClientID == id);
          client.AccountId = newid;
    
          db.SaveChanges();
      }
    }
