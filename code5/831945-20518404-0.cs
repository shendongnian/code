        protected static Ent ctx{get{return DBContextManager.GetDBContext();}}
        private ObjectContext _context;
        private readonly ObjectSet<TBaseEntity> _objectSet;
        public DataRepository(): this(DBContextManager.GetDBContext()){}
        public DataRepository(ObjectContext context)
        {
            _context = context;
            _objectSet = _context.CreateObjectSet<TBaseEntity>();
        }
        private ObjectQuery<TDerivedEntity> TypedObjectSet
        {
            get
            {
                return _objectSet.OfType<TDerivedEntity>();
            }
        }
        public IEnumerable<TDerivedEntity> Find(Expression<Func<TDerivedEntity, bool>> predicate)
        {
            return TypedObjectSet.Where(predicate);
        }
        public TDerivedEntity Single(Func<TDerivedEntity, bool> predicate)
        {
            return TypedObjectSet.Single(predicate);
        }
        // etc etc
