    public List<Table1> DumpTable1(Expression<Func<Table1,bool>> filter)
    {
        using(var context = new MyDbContxt()
        {
             var tableWithoutTracking = context.Table1.AsNoTracking().Where(filter).ToList();
        }
    }
