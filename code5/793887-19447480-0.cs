    private readonly IUnitOfWork _UnitOfWork;
    protected MyContext Context { get { return Uow.Context; } }
    protected IUnitOfWork Uow
    {
        get { return _UnitOfWork; }
    }
    public RepositoryBase(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }
    public virtual IQueryable<T> All
    {
        get
        {
            return Context.Set<T>();
        }
    }
    public virtual IQueryable<T> AllIncluding(params Expression<Func<T
                                              , object>>[] includeProperties)
    {
        IQueryable<T> query = All;
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }
        //string sql = query.ToString();
        return query;
    }
