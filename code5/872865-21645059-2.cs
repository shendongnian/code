    public void SomeMethod()
    {
         using(var session = _sessionFactory.OpenSession(_session))
         {
             var repository = new NHibernateRepo<MyType>();
             var list = repository.MyEntity.Find().Where(e => e.Id ==0).First();
         } //here everything is disposed
    }
