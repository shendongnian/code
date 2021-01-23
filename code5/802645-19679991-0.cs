    private Entities _context;
    public PointsRepository(Entities context)
    {
        _context = context
    }
    public IQueryable<PointsTable> GetAll()
    {
        return context.POINTS_TABLE;
    }
    
    public IQueryable<PointsTable> GetAllComplete()
    {
        return context.POINTS_TABLE.Include("Countries");
    }
