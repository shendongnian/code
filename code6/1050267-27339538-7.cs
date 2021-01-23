    public abstract class BaseRepository<TDAL, TBLL> : IRepository<TBLL>
        where TDAL : BaseEntityDAL, new()
        where TBLL : BaseEntity, new()
    {
        protected readonly MyDbContext context;
        protected readonly DbSet<TDAL> dbSet;
        protected virtual TDAL Map(TBLL obj)
        {
            Mapper.CreateMap<TBLL, TDAL>();
            return Mapper.Map<TDAL>(obj);
        }
        protected virtual TBLL Map(TDAL obj)
        {
            Mapper.CreateMap<TDAL, TBLL>();
            return Mapper.Map<TBLL>(obj);
        }
        protected abstract IQueryable<TBLL> GetIQueryable();            
        public BaseRepository(MyDbContext context, DbSet<TDAL> dbSet)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (dbSet == null)
                throw new ArgumentNullException(nameof(dbSet));
            this.context = context;
            this.dbSet = dbSet;
        }
        public TBLL Get(int id)
        {
            var entity = dbSet
                .Where(i => i.Id == id)
                .FirstOrDefault();
            var result = Map(entity);
            return result;
        }
        public IQueryable<TBLL> Get()
        {
            return GetIQueryable();
        }
        public TBLL Add(TBLL obj)
        {
            var entity = Map(obj);
            dbSet.Add(entity);
            context.SaveChanges();
            obj.Id = entity.Id;
            return obj;
        }
        public TBLL Update(TBLL obj)
        {
            var entity = Map(obj);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return obj;
        }
        public void Delete(TBLL obj)
        {
            TDAL entity = dbSet
                .Where(e => e.Id == obj.Id)
                .FirstOrDefault();
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
