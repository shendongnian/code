    public void SomeMethod()
    {
         var unitOfWork = new UnitOfWork(_sessionFactory);
         try
         {
             var respository = new NHibernateRepo<MyType>();
             var list = repo.MyEntity.Find().Where(e => e.Id ==0).First();
         }
         catch(Exception ex)
         {
             //here goes the session close stuff,
             //transaction rollbacks etc
         }
         finally 
         {
            unitOfWork.Dispose();
         }
   
    }
 
