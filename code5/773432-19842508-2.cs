    Func<EncDataContext,IQueryable<Log>> getBaseLogQuery;
    public Expression<Func<EncDataContext,IQueryable<Log>>> GetBaseLogQuery(EncDataContext context)
    {
        if(getBaseLogQuery==null)
            getBaseLogQuery=GetBaseLogQueryExpr().Compile();
        return getBaseLogQuery(context);
    }
    public Expression<Func<EncDataContext,IQueryable<Log>>> GetBaseLogQueryExpr()
    {
        return context=>from pl in context.DbLog ..... etc ....; // contrainst: this MUST be a lambda.
    }
