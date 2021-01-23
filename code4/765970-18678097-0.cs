    private const int _pageSize = 20;
    public IQueryable<Person> GetPersonBetweenDates(DateTime start, DateTime end, int? page)
    {
         return dbcontext.Persons
                         .Where(x => x.RegisterDate >= start && x.RegisterDate <= end)
                         .OrderBy(x => x.LastName)
                         .ThenBy(x => x.FirstName)
                         .ThenBy(x => x.Id) // using unique id to force consistent total order
                         .Skip((page ?? 0) * _pageSize)
                         .Take(_pageSize);
    }
