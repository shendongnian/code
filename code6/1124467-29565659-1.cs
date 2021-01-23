    public static List<Person> GetPeopleFiltered(IEnumerable<IEnumerable<Expression<Func<Person,bool>>>> filterCategories, List<Person> people)
    {
        var query = people.AsQueryable();
        foreach(var filterCat in filterCategories)
        {
            query = query.Where(x => filterCat.Any(f => f(x)));
        }
        return query.ToList();
    }
