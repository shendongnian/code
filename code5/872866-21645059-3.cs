    public void SomeMethod()
    {
         using(var repository = new NHibernateRepo<MyType>(_sessionFactory))
         {
             var list = repository .MyEntity.Find().Where(e => e.Id ==0).First();
         }
    }
    public class NHibernateRepo<TEntity> : IDisposable{
        private ISession _session;
        
       public NHibernateRepo(ISessionFactory sessionFactory) { 
              _session = sessionFactory.OpenSession();
        }
       public IQueryable<TEntity> Find(){
            try{
                return session.Query<TEntity>();
            }
            catch(Exception ex){
                 //session clear / close 
                 // transaction rollbacks etc.
            }
       }
       public void Dispose(){
         //here goes session close stuff etc.
       }
    }
 
