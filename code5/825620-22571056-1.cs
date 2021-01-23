    public abstract class BaseEntity{ public int Id { get;set; }
    public interface IRepository<T> where T : BaseEntity
    {
        
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;
       
        public EfRepository(IDbContext context)
        {
            this._context = context;
        }
        public virtual T GetById(object id)
        {
            //Check cache first, if exists 
            return this.Entities.Find(id);
        }
        public virtual void Insert(T entity)
        {
            
            if (entity == null)
                    throw new ArgumentNullException("entity");
             
             this.Entities.Add(entity);
             //Add entity to cache
             this._context.SaveChanges();
           
        }
        public virtual void Update(T entity)
        {
            //Update cache
                if (entity == null)
                    throw new ArgumentNullException("entity");
                this._context.SaveChanges();
           
        }
        public virtual void Delete(T entity)
        {
            //Remove from cache
            this.Entities.Remove(entity);
            this._context.SaveChanges();
           
        }
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
