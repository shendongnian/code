    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly UnitOfWork _unitOfWork;
        public Repository()
        {
            this._unitOfWork = new UnitOfWork();
        }
        public Repository(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IList<TEntity> GetAll()
        {
            try
            {
                return this._unitOfWork.context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
        public TEntity GetById(int id)
        {
            try
            {
                return this._unitOfWork.context.Set<TEntity>().Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
        public TEntity Get(TEntity entity)
        {
            try
            {
                return this._unitOfWork.context.Set<TEntity>().Find(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
        public bool Add(TEntity entity)
        {
            try
            {
                this._unitOfWork.context.Set<TEntity>().Add(entity);
                this._unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
        public bool Update(TEntity entity)
        {
            try
            {
                this._unitOfWork.context.Set<TEntity>().Attach(entity);
                this._unitOfWork.context.Entry(entity).State = EntityState.Modified;
                this._unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
        public bool Delete(TEntity entity)
        {
            try
            {
                this._unitOfWork.context.Set<TEntity>().Remove(this.Get(entity));
                this._unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
        public bool DeleteById(int id)
        {
            try
            {
                this._unitOfWork.context.Set<TEntity>().Remove(this.GetById(id));
                this._unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
       }
