    public class PatientPortalUserStore<TUser> : UserStore<TUser>
        where TUser : ApplicationUser
    {
        public PatientPortalUserStore(DbContext context) : base(context)
        {
            this._userStore = new EntityStore<TUser>(context);
        }
        private EntityStore<TUser> _userStore;
        public override Task<TUser> FindByNameAsync(string userName)
        {
            //This is the important piece to loading your own collection on login
            IQueryable<TUser> entitySet =
                from u in this._userStore.EntitySet.Include(u=>u.MyCustomUserCollection)
                where u.UserName.ToUpper() == userName.ToUpper()
                select u;
            return Task.FromResult<TUser>(entitySet.FirstOrDefault<TUser>());
        }
    }
    //Had to define this because EntityStore used by UserStore<TUser> is internal
    class EntityStore<TEntity>
        where TEntity : class
    {
        public DbContext Context
        {
            get;
            private set;
        }
        public DbSet<TEntity> DbEntitySet
        {
            get;
            private set;
        }
        public IQueryable<TEntity> EntitySet
        {
            get
            {
                return this.DbEntitySet;
            }
        }
        public EntityStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.Context = context;
            this.DbEntitySet = context.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            this.DbEntitySet.Add(entity);
        }
        public void Delete(TEntity entity)
        {
            this.Context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }
        public virtual Task<TEntity> GetByIdAsync(object id)
        {
            return this.DbEntitySet.FindAsync(new object[] { id });
        }
    }
