    private IQueryable<Person> qry = dbcontext.Persons.Where(x => x.RegisterDate >= start && x.RegisterDate <= end);
    public IQueryable<Person> GetPersonBetweenDates(DateTime start, DateTime end)
    {
        qry = qry.Skip(20);
        return qry.Take(20);
    }
