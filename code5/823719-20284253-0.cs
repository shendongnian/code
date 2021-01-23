    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Get();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
        T GetByID(Object id);
    }
    public class GenericRepository<C, T> : IGenericRepository<T>
        where T : class
        where C : EFDbContext, new()
    {
        private C _entities = new C();
        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }
        public virtual IQueryable<T> Get()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }
        public virtual T GetByID(object id)
        {
            return Context.Set<T>().Find(id);
        }
    }
    //NinjectControllerFactory
    private void AddBindings()
    {
    _ninjectKernel.Bind<IGenericRepository<Product>>().To<GenericRepository<EFDbContext, Product>>();
    }
    //Controller
    [Inject]
    public IGenericRepository<Product> ProductRepo;
    public ProductController(IGenericRepository<Product> ProductRepository )
        {
            ProductRepo= ProductRepository ;
        }
    //Inside Action
    model.Products = ProductRepo.Get();
