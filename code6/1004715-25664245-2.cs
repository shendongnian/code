    public interface IUnitOfWork : IDisposable
    {
        ISession CurrentSession { get; }
        void Commit();
        void Rollback();
    }
    
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;
        
        [ThreadStatic]
        private ISession _session;
     
        [ThreadStatic]
        private ITransaction _transaction;
    
        public NHibernateUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            _session = _sessionFactory.OpenSession();
            _transaction = _session.BeginTransaction();
        }
    
        public static ISession CurrentSession { get { return _session; } }
    
        public void Dispose()
        {
            _transaction = null;
            _session.Close();
            _session = null;
        }
    
        public void Commit()
        {
            _transaction.Commit();
        }
    
        public void Rollback()
        {
            if (_transaction.IsActive) _transaction.Rollback();
        }
    }
    
    public class Repository : IRepository
    {
        public void Add(IObj obj)
        {
            if (NHibernateUnitOfWork.CurrentSession == null)
                throw new Exception("No unit of work present");
    
            NHibernateUnitOfWork.CurrentSession.Save(obj);         
        }
    }
    
    // ASP.NET MVC controller, but valid for any
    // other arbitary application service
    public class MyController : Controller 
    {
        private readonly IPeopleRepository _repository;
    
        // di -> declaring IPeopleRepository dependency
        public MyController(IPeopleRepository repository) {
            _repository = repository;
        }
    
        public void AddPerson(Person person) 
        {
            using (IUnitOfWork uow = new NHibernateUnitOfWork())
            {
                try
                { 
                    _repository.Add(person);
                    uow.Commit();
                }
                catch(Exception ex)
                {
                   uow.RollBack();
                }
            }
        }
     }
