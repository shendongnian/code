    public void SomeMethod()
    {
         
         using(var session = _sessionFactory.OpenSession(_session))
         {
             var respository = new NHibernateRepo<MyType>();
             var list = repo.MyEntity.Find().Where(e => e.Id ==0).First();
         } //here everything is disposed
           
         
    }
