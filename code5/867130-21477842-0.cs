    var persons = context.PERSON.AsQueryable();
    if(!string.IsNullOrEmpty(age))
    {
        persons = persons.Where(p => p.age == age);
    }
    if(!string.IsNullOrEmpty(name))
    {
        persons = persons.Where(p => p.name.StartsWith(name));
    }
    //some similar filtering...
    return persons.ToList();
