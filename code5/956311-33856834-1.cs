    [EnableQuery]
    public IQueryable<Student> Get_Student(ODataQueryOptions<Student> queryOptions)
    {
    var db = new EfCustomAdapter();
          
    var  expandOpts = new SelectExpandQueryOption(null, "Parent,Schools", queryOptions.Context);
    var q = db.Student.AsQueryable();
    q = q.Include(t => t.Parent);
    q = q.Include(t => t.Schools);
    queryOptions.Request.ODataProperties().SelectExpandClause = expandOpts.SelectExpandClause;
    return q;
    }
