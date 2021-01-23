    private int counter = 0;
    public IQueryable<Person> GetPersonBetweenDates(DateTime start, DateTime end)
    {
        var results = dbcontext.Persons.Where(x => x.RegisterDate >= start && x.RegisterDate <= end).Skip(counter).Take(20);
        counter += 20;
        return results;
    }
