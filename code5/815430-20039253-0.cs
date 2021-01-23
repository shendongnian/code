    private IList<Func<IQueryable<Person>, IQueryable<Person>>> filters;
    
    public Repository FilterByAge(int age)
    {
        var _filters = new List<Func<IQueryable<Person>, IQueryable<Person>>>(filters);
        _filters.Add(q => q.Where(e => e.Age == age));
        return new Repository(_filters);
    }
    
    public Repository OrderByName()
    {
        var _filters = new List<Func<IQueryable<Entity>, IQueryable<Entity>>>(filters);
        _filters.Add(q => q.OrderBy(e => e.Name));
        return new Repository(_filters);
    }
    private IQueryable<Person> ApplyFilters(AppContext db)
    {
        var result = db.People;
        foreach (var filter in filters)
        {
            result = filter(result);
        }
        return result;
    }
    public IEnumerable<Person> GetPeople()
    {
        IEnumerable<Person> people;
        using (var db = new AppContext())
        {
            people = ApplyFilters(db).ToList();
        }
        return people;
    }
