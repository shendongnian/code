    public class UnitOfWork
    {
         private ISomeEntityRepository _someEntityRepository;
         public ISomeEntityRepository SomeEntityRepository
         {
             get
             {
                  if ( _someEntityRepository == null )
                        _someEntityRepository = new ...
                  return _someEntityRepository;
             }
