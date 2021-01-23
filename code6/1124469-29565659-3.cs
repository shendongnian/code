    public static List<Person> GetPeopleFiltered(IEnumerable<IEnumerable<Func<Person,bool>>> filterCategories, List<Person> people)
    {
        var query = people;
        foreach(var filterCat in filterCategories)
        {
            query = query.Where(x => filterCat.Any(f => f(x)));
        }
        return query.ToList();
    }
