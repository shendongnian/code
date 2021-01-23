    public override bool UpdateItem(DbUser item)
    {
      using (var work = new UnitOfWork())
      {
        var repository = new UserDataRepository(work);
        DbUser managedUser = repository.Get(item.PK);
        //foreach DbUser property map the item to managedUser
        managedUser.field1 = item.field1;
        [..]
        
        repository.Update(managedUser);
        repository.Save();
      }
    }
