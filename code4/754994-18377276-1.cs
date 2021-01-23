    public bool SaveData(...)
    {
      using (var session = <NAMESPACE HERE>.SessionFactory.OpenSession())
      {
        using (var tran = session.BeginTransaction())
        {
          Address adress = new Address();
          adress.City= City;
          ...
          session.Save(address);
          tran.commit();
        }
      }
      return true;
    }
